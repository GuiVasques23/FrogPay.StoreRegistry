using System;
using System.Threading.Tasks;
using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Context;
using FrogPay.StoreRegistry.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.StoreRegistry.Infra.Repositories
{
    public class DadosBancariosRepository : BaseRepository<DadosBancarios>, IDadosBancariosRepository
    {
        public DadosBancariosRepository(StoreRegistryDbContext context) : base(context)
        {
        }

        public async Task<DadosBancarios> GetDadosBancariosByIdPessoaAsync(Guid idPessoa)
        {
            return await _context.DadosBancarios.FirstOrDefaultAsync(d => d.IdPessoa == idPessoa);
        }
    }
}
