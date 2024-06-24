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
            try
            {
                var dadosBancarios = await _context.DadosBancarios
                    .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);

                if (dadosBancarios == null)
                {
                    throw new InvalidOperationException("Dados bancários não encontrados.");
                }

                return dadosBancarios;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar os dados bancários pelo ID da pessoa.", ex);
            }
        }
    }
}
