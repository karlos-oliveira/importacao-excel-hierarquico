using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Models
{
    public class Ambiente
    {
        public Ambiente()
        {
            Descricao = "vazio";
            TipoAmbiente = new TipoAmbiente();
            Filhos = new List<Ambiente>();
            IsAtivo = true;
        }

        public Ambiente(Guid _id, string _descricao, Guid _idPai, string _observacao)
        {
            Id = _id;
            Descricao = _descricao;
            Observacao = _observacao;
            IdPai = _idPai;
            TipoAmbiente = new TipoAmbiente();
            IsAtivo = true;
        }

        public Ambiente(string _descricao, Guid? _idPai)
        {
            Id = Guid.NewGuid();
            Descricao = _descricao;
            IdPai = _idPai;
            TipoAmbiente = new TipoAmbiente();
            Filhos = new List<Ambiente>();
            IsAtivo = true;
        }

        public Guid Id { get; set; }
        public Guid? IdPai { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public Guid IdTipoAmbiente { get; set; }
        public Guid IdImportacao { get; set; }
        public TipoAmbiente TipoAmbiente { get; set; }
        public List<Ambiente> Filhos { get; set; }
        public bool IsAtivo { get; set; }
    }
}
