using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Models
{
    public class TipoAmbiente
    {
        public TipoAmbiente()
        {

        }

        public TipoAmbiente(string _descricao)
        {
            Id = Guid.NewGuid();
            Descricao = _descricao;
            IsAtivo = true;
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
