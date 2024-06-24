using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Services
{
    public class LojaService : ILojaService
    {
        public Task CreateLojaAsync(Loja loja)
        {
            throw new NotImplementedException();
        }

        public Task<Loja> GetLojaByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLojaAsync(Loja loja)
        {
            throw new NotImplementedException();
        }
    }
}
