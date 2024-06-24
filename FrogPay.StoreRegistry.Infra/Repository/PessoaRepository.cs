using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Interfaces;
using FrogPay.StoreRegistry.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Infra.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(StoreRegistryDbContext context) : base(context)
        {
        }
    }
}
