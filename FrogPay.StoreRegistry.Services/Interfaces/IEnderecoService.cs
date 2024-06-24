using FrogPay.StoreRegistry.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoByIdPessoa(Guid id);
        Task<Endereco> GetEnderecoByName(string name);
        Task CreateEnderecoAsync(Endereco endereco);
        Task UpdateEnderecoAsync(Endereco endereco);
    }
}
