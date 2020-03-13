using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Models
{
    public class ImportacaoAmbienteInput
    {
        public string CampoLocal { get; set; }
        public string CampoArea { get; set; }
        public string CampoSetor { get; set; }
        public string CampoAmbiente { get; set; }
        public string CampoObservacao { get; set; }
        public string CampoTipoAmbiente { get; set; }
        public int WorksheetIndex { get; set; }
        public byte[] Arquivo { get; set; }
        public string[] Agrupadores { get; set; }

    }
}
