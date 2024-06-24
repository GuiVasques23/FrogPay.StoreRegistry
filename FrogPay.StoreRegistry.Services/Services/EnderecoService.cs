using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Services
{
    public class EnderecoService : IEnderecoService
    {
        public Task CreateEnderecoAsync(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> GetEnderecoByIdPessoa(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> GetEnderecoByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEnderecoAsync(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
