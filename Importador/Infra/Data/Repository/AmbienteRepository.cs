using Importador.Models;
using Importador.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Infra.Data.Repository
{

    public class AmbienteRepository : IAmbienteRepository
    {
        private readonly IContext _context;

        public AmbienteRepository(IContext context)
        {
            _context = context;
        }

        public Ambiente ConsultarAmbiente(Guid IdAmbiente)
        {
            return _context.Ambiente.Where(x => x.Id == IdAmbiente).First();
        }

        public List<Ambiente> ConsultarAmbientes()
        {
            return _context.Ambiente.Where(x => x.IsAtivo).ToList();
        }

        public List<Ambiente> ConsultarAmbientesPorIdPai(Guid idImportacao, Guid? idPai)
        {
            return _context.Ambiente.Where(x => x.IsAtivo
                                        && x.IdImportacao == idImportacao
                                        && x.IdPai == idPai).ToList();
        }

        public void CriarAmbiente(Ambiente inputs)
        {
            _context.Ambiente.Add(inputs);
            _context.Commit();
        }

        public void DeletarAmbiente(Guid IdAmbiente)
        {
            _context.Ambiente.Find(IdAmbiente).IsAtivo = false;
            _context.Commit();
        }

        public void EditarAmbiente(Ambiente inputs)
        {
            _context.Ambiente.Update(inputs);
            _context.Commit();
        }
    }

}
