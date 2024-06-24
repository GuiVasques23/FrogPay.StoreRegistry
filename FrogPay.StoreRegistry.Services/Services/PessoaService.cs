using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Services
{
    public class PessoaService : IPessoaService
    {
        public Task CreatePessoaAsync(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<Pessoa> GetPessoaByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePessoaAsync(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
