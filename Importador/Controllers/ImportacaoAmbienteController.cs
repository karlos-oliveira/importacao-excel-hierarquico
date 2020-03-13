using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClosedXML.Excel;
using Importador.Models;
using Importador.Services;
using Importador.Shared;
using System.IO;

namespace Importador.Controllers
{

    [Route("api/v1/importacao-ambiente")]
    [ApiController]
    public class ImportacaoAmbienteController : ControllerBase
    {
        private readonly IImportacaoAmbienteService _serv;
        private readonly ITipoAmbienteService _tpAmbienteServ;
        private readonly IAmbienteService _ambienteServ;
        private Guid idImportacao;
        public ImportacaoAmbienteController(IImportacaoAmbienteService serv, ITipoAmbienteService tpAmbienteServ, IAmbienteService ambienteServ)
        {
            _serv = serv;
            _tpAmbienteServ = tpAmbienteServ;
            _ambienteServ = ambienteServ;
        }

        [HttpPost]
        [RequestSizeLimit(52428800)]
        public ActionResult CriarImportacao([FromBody] ImportacaoAmbienteInput inputs)
        {
            try
            {
                var wsIndex = inputs.WorksheetIndex < 1 ? 1 : inputs.WorksheetIndex;
                Stream arq = new MemoryStream(inputs.Arquivo);
                var wb = new XLWorkbook(arq);
                var ws = wb.Worksheet(wsIndex);
                var firstCell = ws.FirstCellUsed().Address;
                var LastCell = ws.LastCellUsed().Address;

                var tabela = ws.Range(firstCell, LastCell).AsTable("import");

                var importacaoDinamica = ImportacaoExcelCamposDinamicos(tabela, inputs);

                _serv.CriarImportacaoAmbiente(importacaoDinamica);

                return Ok(importacaoDinamica);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo ImportacaoAmbiente: {ex.Message}");
            }
        }
        private ImportacaoAmbiente ImportacaoExcelCamposDinamicos(IXLTable tabela, ImportacaoAmbienteInput inputs)
        {
            try
            {
                var importacaoDinamica = new ImportacaoAmbiente();
                idImportacao = importacaoDinamica.IdImportacao;

                var linhasAgrupadasDinamicamente = tabela.DataRange.Rows().GroupBy(q => new DynamicDataRowGroup(q, inputs.Agrupadores)).ToList();

                linhasAgrupadasDinamicamente.ForEach(group =>
                {
                    string campoControle = group.ToList()?.First()?.Field(0)?.GetString();

                    if(!string.IsNullOrEmpty(campoControle))
                    {
                        group.ToList().ForEach(linha =>
                        {
                            var agr = importacaoDinamica.Filhos;
                            Guid? idPaiAux = null;
                            inputs.Agrupadores.ToList().ForEach(colunaAgrupadora =>
                            {
                                var descricaoAmbiente = linha.Field(colunaAgrupadora).GetString();
                                var descricaoTipoAmbiente = linha.Field(inputs.CampoTipoAmbiente).GetString();

                                var result = CriarArvore(agr, descricaoAmbiente, idPaiAux, descricaoTipoAmbiente);

                                agr = result.Item2;
                                idPaiAux = result.Item1;
                            });

                            var ambiente = new Ambiente(linha.Field(inputs.CampoAmbiente).GetString(), idPaiAux);
                            ambiente.TipoAmbiente = _tpAmbienteServ.BuscarOuCriar(linha.Field(inputs.CampoTipoAmbiente).GetString());
                            ambiente.IdTipoAmbiente = ambiente.TipoAmbiente.Id;
                            ambiente.IdImportacao = idImportacao;

                            agr.Add(ambiente);
                            _ambienteServ.CriarAmbiente(ambiente);
                        });
                    }
                });

                return importacaoDinamica;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Tuple<Guid?, List<Ambiente>> CriarArvore(List<Ambiente> lstAmbientes, string descricao, Guid? idPai, string descTipoAmbiente)
        {
            try
            {
                if(string.IsNullOrEmpty(descricao))
                    return new Tuple<Guid?, List<Ambiente>> (idPai, lstAmbientes);

                var ambiente = new Ambiente(descricao, idPai);

                var _pai = lstAmbientes.Find(_amb => string.Equals(_amb.Descricao, ambiente.Descricao));

                if (_pai == null)
                {
                    ambiente.TipoAmbiente = _tpAmbienteServ.BuscarOuCriar(descTipoAmbiente);
                    ambiente.IdTipoAmbiente = ambiente.TipoAmbiente.Id;
                    ambiente.IdImportacao = idImportacao;

                    _ambienteServ.CriarAmbiente(ambiente);
                    lstAmbientes.Add(ambiente);
                    return new Tuple<Guid?, List<Ambiente>>(ambiente.Id, ambiente.Filhos);
                }

                return new Tuple<Guid?, List<Ambiente>>(_pai.Id, _pai.Filhos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{idImportacaoAmbiente}")]
        public ActionResult ConsultarImportacaoAmbiente([FromRoute] Guid IdImportacaoAmbiente)
        {
            try
            {
                var importAmbiente = _serv.ConsultarImportacaoAmbiente(IdImportacaoAmbiente);
                idImportacao = importAmbiente.IdImportacao;

                PreencheFilhos(importAmbiente.Filhos);

                return Ok(importAmbiente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar a Importacao Ambiente {IdImportacaoAmbiente}: {ex.Message}");
            }
        }

        private void PreencheFilhos(List<Ambiente> lstAmbientes, Guid? idPai = null)
        {
            lstAmbientes.AddRange(_ambienteServ.ConsultarAmbientesPorIdPai(idImportacao, idPai));

            lstAmbientes.ForEach(ambiente =>
            {
                ambiente.TipoAmbiente = _tpAmbienteServ.ConsultarTipoAmbiente(ambiente.IdTipoAmbiente);
                PreencheFilhos(ambiente.Filhos, ambiente.Id);
            });
        }

        [HttpGet]
        public ActionResult ConsultarImportacaoAmbientes()
        {
            try
            {
                var response = _serv.ConsultarImportacaoAmbientes();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar as Importações Ambiente: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarImportacaoAmbiente([FromBody] ImportacaoAmbiente inputs)
        {
            try
            {
                _serv.EditarImportacaoAmbiente(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o ImportacaoAmbiente {inputs.IdImportacao}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idImportacaoAmbiente}")]
        public ActionResult DeletarImportacaoAmbiente([FromRoute] Guid IdImportacaoAmbiente)
        {
            try
            {
                _serv.DeletarImportacaoAmbiente(IdImportacaoAmbiente);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar a Importacao Ambiente {IdImportacaoAmbiente}: {ex.Message}");
            }
        }
        private string getHeaderTratado(IXLTable tabela, string campoPesq)
        {
            var campoRetorno = tabela.Fields.Select(campo => campo.HeaderCell.GetString())
                                            .ToList()
                                            .Find(header => string.Equals(header.Trim().ToLower(), campoPesq.Trim().ToLower()));

            return campoRetorno;
        }

        private int getHeaderIndex(IXLTable tabela, string campoPesq)
        {
            var index = tabela.Fields.Select(campo => campo)
                                            .ToList()
                                            .Find(header => string.Equals(header.Name.Trim().ToLower(), campoPesq.Trim().ToLower()))
                                            ?.Index;

            return index.HasValue ? index.Value : -1;
        }
    }

}