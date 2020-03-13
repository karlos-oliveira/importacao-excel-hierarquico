using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Models
{
    public class ImportacaoAmbiente
    {
        public ImportacaoAmbiente()
        {
            IdImportacao = Guid.NewGuid();
            Filhos = new List<Ambiente>();
            DataImportacaoUTC = DateTime.UtcNow;
        }
        public Guid IdImportacao { get; set; }
        public List<Ambiente> Filhos { get; set; }
        public DateTime DataImportacaoUTC { get; set; }
    }
}
