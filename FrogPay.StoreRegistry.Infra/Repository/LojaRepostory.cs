using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Context;
using FrogPay.StoreRegistry.Infra.Interfaces;
using FrogPay.StoreRegistry.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Infra.Repository
{
    public class LojaRepository : BaseRepository<Loja>, ILojaRepository
    {
        public LojaRepository(StoreRegistryDbContext context) : base(context)
        {
        }
    }
}
