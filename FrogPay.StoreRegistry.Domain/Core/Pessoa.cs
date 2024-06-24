using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Domain.Core
{
    public class Pessoa
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<DadosBancarios> DadosBancarios { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Loja> Lojas { get; set; }
    }
}
