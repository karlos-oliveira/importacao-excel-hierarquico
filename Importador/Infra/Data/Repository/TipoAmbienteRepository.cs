using Importador.Models;
using Importador.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Infra.Data.Repository
{

    public class TipoAmbienteRepository : ITipoAmbienteRepository
    {
        private readonly IContext _context;

        public TipoAmbienteRepository(IContext context)
        {
            _context = context;
        }

        public TipoAmbiente BuscarOuCriar(string ambienteNome)
        {
            ambienteNome = ambienteNome.Trim();

            var tpsAmbientes = _context.TipoAmbiente.Where(x => x.Descricao.Trim().ToLower() == ambienteNome.ToLower()).ToList();
            TipoAmbiente tipoAmbiente;

            if (tpsAmbientes.Count == 0)
            {
                tipoAmbiente = new TipoAmbiente(ambienteNome);
                CriarTipoAmbiente(tipoAmbiente);
            }
            else
            {
                tipoAmbiente = tpsAmbientes.First();
            }

            return tipoAmbiente;
        }

        public TipoAmbiente ConsultarTipoAmbiente(Guid IdTipoAmbiente)
        {
            return _context.TipoAmbiente.Where(x => x.Id == IdTipoAmbiente).First();
        }

        public List<TipoAmbiente> ConsultarTipoAmbientes()
        {
            return _context.TipoAmbiente.Where(x => x.IsAtivo).ToList();
        }

        public void CriarTipoAmbiente(TipoAmbiente inputs)
        {
            _context.TipoAmbiente.Add(inputs);
            _context.Commit();
        }

        public void DeletarTipoAmbiente(Guid IdTipoAmbiente)
        {
            _context.TipoAmbiente.Find(IdTipoAmbiente).IsAtivo = false;
            _context.Commit();
        }

        public void EditarTipoAmbiente(TipoAmbiente inputs)
        {
            _context.TipoAmbiente.Update(inputs);
            _context.Commit();
        }
    }

}
