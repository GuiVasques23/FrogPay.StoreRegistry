using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Domain.Core
{
    public class Loja
    {
        public Guid? Id { get; set; }
        public Guid IdPessoa { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateOnly DataAbertura { get; set; }
    }
}
