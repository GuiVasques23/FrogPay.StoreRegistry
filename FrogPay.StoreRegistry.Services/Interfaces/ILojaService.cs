using FrogPay.StoreRegistry.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Interfaces
{
    public interface ILojaService
    {
        Task<Loja> GetLojaByIdAsync(Guid id);
        Task CreateLojaAsync(Loja loja);
        Task UpdateLojaAsync(Loja loja);
    }
}
