using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Infra.Data.Repository
{

    public interface IAmbienteRepository
    {
        void CriarAmbiente(Ambiente inputs);
        Ambiente ConsultarAmbiente(Guid IdAmbiente);
        List<Ambiente> ConsultarAmbientes();
        List<Ambiente> ConsultarAmbientesPorIdPai(Guid idImportacao, Guid? idPai);
        void EditarAmbiente(Ambiente inputs);
        void DeletarAmbiente(Guid IdAmbiente);
    }

}
