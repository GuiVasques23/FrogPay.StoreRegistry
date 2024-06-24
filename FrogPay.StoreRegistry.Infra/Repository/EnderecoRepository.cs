using System;
using System.Threading.Tasks;
using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Context;
using FrogPay.StoreRegistry.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.StoreRegistry.Infra.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(StoreRegistryDbContext context) : base(context)
        {
        }

        public async Task<Endereco> GetEnderecoByIdPessoaAsync(Guid idPessoa)
        {
            try
            {
                var endereco = await _context.Enderecos
                    .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);

                if (endereco == null)
                {
                    throw new InvalidOperationException("Endereço não encontrado.");
                }

                return endereco;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar o endereço pelo ID da pessoa.", ex);
            }
        }
    }
}



