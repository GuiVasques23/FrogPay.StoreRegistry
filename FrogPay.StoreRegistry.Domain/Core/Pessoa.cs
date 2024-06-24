using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Domain.Core
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public ICollection<DadosBancarios> DadosBancarios { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Loja> Lojas { get; set; }
    }
}
