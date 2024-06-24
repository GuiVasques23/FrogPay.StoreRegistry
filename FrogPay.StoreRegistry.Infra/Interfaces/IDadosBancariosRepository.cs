using FrogPay.StoreRegistry.Domain.Core;
using System;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Infra.Interfaces
{
    public interface IDadosBancariosRepository : IBaseRepository<DadosBancarios>
    {
        Task<DadosBancarios> GetDadosBancariosByIdPessoaAsync(Guid idPessoa);
    }
}
