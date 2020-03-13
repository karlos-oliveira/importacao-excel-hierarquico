using Importador.Infra.Data.Repository;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Services
{

    public class ImportacaoAmbienteService : IImportacaoAmbienteService
    {
        private readonly IImportacaoAmbienteRepository _repo;
        public ImportacaoAmbienteService(IImportacaoAmbienteRepository repo)
        {
            _repo = repo;
        }

        public ImportacaoAmbiente ConsultarImportacaoAmbiente(Guid IdImportacaoAmbiente)
        {
            return _repo.ConsultarImportacaoAmbiente(IdImportacaoAmbiente);
        }

        public List<ImportacaoAmbiente> ConsultarImportacaoAmbientes()
        {
            return _repo.ConsultarImportacaoAmbientes();
        }

        public void CriarImportacaoAmbiente(ImportacaoAmbiente inputs)
        {
            _repo.CriarImportacaoAmbiente(inputs);
        }

        public void DeletarImportacaoAmbiente(Guid IdImportacaoAmbiente)
        {
            _repo.DeletarImportacaoAmbiente(IdImportacaoAmbiente);
        }

        public void EditarImportacaoAmbiente(ImportacaoAmbiente inputs)
        {
            _repo.EditarImportacaoAmbiente(inputs);
        }
    }

}
