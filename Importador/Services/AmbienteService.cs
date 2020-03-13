using Importador.Infra.Data.Repository;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Services
{

    public class AmbienteService : IAmbienteService
    {
        private readonly IAmbienteRepository _repo;
        public AmbienteService(IAmbienteRepository repo)
        {
            _repo = repo;
        }

        public Ambiente ConsultarAmbiente(Guid IdAmbiente)
        {
            return _repo.ConsultarAmbiente(IdAmbiente);
        }

        public List<Ambiente> ConsultarAmbientes()
        {
            return _repo.ConsultarAmbientes();
        }

        public List<Ambiente> ConsultarAmbientesPorIdPai(Guid idImportacao, Guid? idPai)
        {
            return _repo.ConsultarAmbientesPorIdPai(idImportacao, idPai);
        }

        public void CriarAmbiente(Ambiente inputs)
        {
            _repo.CriarAmbiente(inputs);
        }

        public void DeletarAmbiente(Guid IdAmbiente)
        {
            _repo.DeletarAmbiente(IdAmbiente);
        }

        public void EditarAmbiente(Ambiente inputs)
        {
            _repo.EditarAmbiente(inputs);
        }
    }

}
