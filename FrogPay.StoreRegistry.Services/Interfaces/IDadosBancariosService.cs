using FrogPay.StoreRegistry.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Interfaces
{
    public interface IDadosBancariosService
    {
        Task<DadosBancarios> GetDadosBancariosByIdPessoa(Guid id);
        Task CreateDadosBancariosAsync(DadosBancarios dadosBancarios);
        Task UpdateDadosBancariosAsync(DadosBancarios dadosBancarios);
    }
}
