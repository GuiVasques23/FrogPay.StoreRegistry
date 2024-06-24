using FrogPay.StoreRegistry.Domain.Core;
using System;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Infra.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<Endereco> GetEnderecoByIdPessoaAsync(Guid idPessoa);
    }
}
