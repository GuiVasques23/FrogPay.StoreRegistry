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
            return await _context.Enderecos.FirstOrDefaultAsync(e => e.IdPessoa == idPessoa);
        }
    }
}



