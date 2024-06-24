using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Interfaces;
using FrogPay.StoreRegistry.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.StoreRegistry.Services.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IPessoaService _pessoaService;
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IPessoaService pessoaService, IEnderecoRepository enderecoRepository)
        {
            _pessoaService = pessoaService;
            _enderecoRepository = enderecoRepository;
        }

        public async Task CreateEnderecoAsync(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco), "Endereço não pode ser nulo");
            }

            try
            {
                await _enderecoRepository.AddAsync(endereco);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao criar o endereço", ex);
            }
        }

            public async Task<Endereco> GetEnderecoByIdPessoa(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID inválido", nameof(id));
            }

            try
            {
                var endereco = await _enderecoRepository.GetEnderecoByIdPessoaAsync(id);

                if (endereco == null)
                {
                    throw new InvalidOperationException("Endereço não encontrado");
                }

                return endereco;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar o endereço pelo ID da pessoa", ex);
            }
        }

        public async Task<Endereco> GetEnderecoByName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "Nome não pode ser nulo");

            try
            {
                var pessoa = await _pessoaService.GetPessoaByNameAsync(name);

                if (pessoa == null)
                {
                    throw new InvalidOperationException("Pessoa não encontrada");
                }

                return await _enderecoRepository.GetEnderecoByIdPessoaAsync(pessoa.Id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar o endereço pelo nome", ex);
            }
        }

        public async Task UpdateEnderecoAsync(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco), "Endereço não pode ser nulo");
            }

            try
            {
                await _enderecoRepository.UpdateAsync(endereco);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao atualizar o endereço", ex);
            }
        }
    }
}
