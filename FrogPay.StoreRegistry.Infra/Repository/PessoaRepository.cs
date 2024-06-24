using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Interfaces;
using FrogPay.StoreRegistry.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.StoreRegistry.Infra.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(StoreRegistryDbContext context) : base(context)
        {
        }

        public async Task<Pessoa> GetPessoaByNameAsync(string name)
        {
            try
            {
                var pessoa = await _context.Pessoas
                    .FirstOrDefaultAsync(p => EF.Functions.Like(p.Nome, $"%{name}%"));

                if (pessoa == null)
                {
                    throw new InvalidOperationException("Nome não encontrado.");
                }

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar a pessoa pelo nome.", ex);
            }
        }
    }
}
