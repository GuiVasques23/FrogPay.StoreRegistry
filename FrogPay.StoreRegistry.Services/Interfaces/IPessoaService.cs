using FrogPay.StoreRegistry.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<Pessoa> GetPessoaByIdAsync(Guid id);
        Task CreatePessoaAsync(Pessoa pessoa);
        Task UpdatePessoaAsync(Pessoa pessoa);
        Task<Pessoa> GetPessoaByNameAsync(string name);
    }
}
