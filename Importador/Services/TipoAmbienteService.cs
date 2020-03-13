using Importador.Infra.Data.Repository;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Services
{

    public class TipoAmbienteService : ITipoAmbienteService
    {
        private readonly ITipoAmbienteRepository _repo;
        public TipoAmbienteService(ITipoAmbienteRepository repo)
        {
            _repo = repo;
        }

        public TipoAmbiente BuscarOuCriar(string ambienteNome)
        {
            return _repo.BuscarOuCriar(ambienteNome);
        }

        public TipoAmbiente ConsultarTipoAmbiente(Guid IdTipoAmbiente)
        {
            return _repo.ConsultarTipoAmbiente(IdTipoAmbiente);
        }

        public List<TipoAmbiente> ConsultarTipoAmbientes()
        {
            return _repo.ConsultarTipoAmbientes();
        }

        public void CriarTipoAmbiente(TipoAmbiente inputs)
        {
            _repo.CriarTipoAmbiente(inputs);
        }

        public void DeletarTipoAmbiente(Guid IdTipoAmbiente)
        {
            _repo.DeletarTipoAmbiente(IdTipoAmbiente);
        }

        public void EditarTipoAmbiente(TipoAmbiente inputs)
        {
            _repo.EditarTipoAmbiente(inputs);
        }
    }

}
