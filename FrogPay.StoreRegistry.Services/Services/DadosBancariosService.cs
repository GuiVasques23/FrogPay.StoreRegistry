using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Services
{
    public class DadosBancariosService : IDadosBancariosService
    {
        public Task CreateDadosBancariosAsync(DadosBancarios dadosBancarios)
        {
            throw new NotImplementedException();
        }

        public Task<DadosBancarios> GetDadosBancariosByIdPessoa(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDadosBancariosAsync(DadosBancarios dadosBancarios)
        {
            throw new NotImplementedException();
        }
    }
}
