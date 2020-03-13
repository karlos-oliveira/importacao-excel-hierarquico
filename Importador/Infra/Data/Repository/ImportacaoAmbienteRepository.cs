using Importador.Models;
using Importador.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Infra.Data.Repository
{

    public class ImportacaoAmbienteRepository : IImportacaoAmbienteRepository
    {
        private readonly IContext _context;

        public ImportacaoAmbienteRepository(IContext context)
        {
            _context = context;
        }

        public ImportacaoAmbiente ConsultarImportacaoAmbiente(Guid IdImportacaoAmbiente)
        {
            return _context.ImportacaoAmbiente.Where(x => x.IdImportacao == IdImportacaoAmbiente).First();
        }

        public List<ImportacaoAmbiente> ConsultarImportacaoAmbientes()
        {
            return _context.ImportacaoAmbiente.ToList();
        }

        public void CriarImportacaoAmbiente(ImportacaoAmbiente inputs)
        {
            _context.ImportacaoAmbiente.Add(inputs);
            _context.Commit();
        }

        public void DeletarImportacaoAmbiente(Guid IdImportacaoAmbiente)
        {
            throw new NotImplementedException();
        }

        public void EditarImportacaoAmbiente(ImportacaoAmbiente inputs)
        {
            _context.ImportacaoAmbiente.Update(inputs);
            _context.Commit();
        }
    }

}
