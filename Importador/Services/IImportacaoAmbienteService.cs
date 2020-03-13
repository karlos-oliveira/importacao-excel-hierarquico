using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Services
{

    public interface IImportacaoAmbienteService
    {
        void CriarImportacaoAmbiente(ImportacaoAmbiente inputs);
        ImportacaoAmbiente ConsultarImportacaoAmbiente(Guid IdImportacaoAmbiente);
        List<ImportacaoAmbiente> ConsultarImportacaoAmbientes();
        void EditarImportacaoAmbiente(ImportacaoAmbiente inputs);
        void DeletarImportacaoAmbiente(Guid IdImportacaoAmbiente);
    }

}
