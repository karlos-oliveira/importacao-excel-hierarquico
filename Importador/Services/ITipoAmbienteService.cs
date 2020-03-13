using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Services
{

    public interface ITipoAmbienteService
    {
        TipoAmbiente BuscarOuCriar(string ambienteNome);
        void CriarTipoAmbiente(TipoAmbiente inputs);
        TipoAmbiente ConsultarTipoAmbiente(Guid IdTipoAmbiente);
        List<TipoAmbiente> ConsultarTipoAmbientes();
        void EditarTipoAmbiente(TipoAmbiente inputs);
        void DeletarTipoAmbiente(Guid IdTipoAmbiente);
    }

}
