using FrogPay.StoreRegistry.API.Controllers;
using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FrogPay.StoreRegistry.Tests
{
    public class EnderecoControllerTests
    {
        private readonly Mock<IEnderecoService> _enderecoServiceMock;
        private readonly EnderecoController _controller;

        public EnderecoControllerTests()
        {
            _enderecoServiceMock = new Mock<IEnderecoService>();
            _controller = new EnderecoController(_enderecoServiceMock.Object);
        }

        [Fact]
        public async Task BuscarEnderecoPorIdPessoa_Existente_DeveRetornarStatusCode200()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            var endereco = new Endereco { IdPessoa = pessoaId, Logradouro = "Rua Teste" };
            _enderecoServiceMock.Setup(service => service.GetEnderecoByIdPessoa(pessoaId)).ReturnsAsync(endereco);

            // Act
            var resultado = await _controller.GetEnderecoByIdPessoa(pessoaId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            var enderecoRetornado = Assert.IsType<Endereco>(okResult.Value);
            Assert.Equal(pessoaId, enderecoRetornado.IdPessoa);
        }

        [Fact]
        public async Task BuscarEnderecoPorIdPessoa_NaoEncontrado_DeveRetornarStatusCode404()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            _enderecoServiceMock.Setup(service => service.GetEnderecoByIdPessoa(pessoaId)).ReturnsAsync((Endereco)null);

            // Act
            var resultado = await _controller.GetEnderecoByIdPessoa(pessoaId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task CriarEndereco_Valido_DeveRetornarStatusCode201()
        {
            // Arrange
            var endereco = new Endereco { IdPessoa = Guid.NewGuid(), Logradouro = "Rua Nova" };

            // Act
            var resultado = await _controller.CreateEndereco(endereco);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(resultado);
            var enderecoRetornado = Assert.IsType<Endereco>(createdAtActionResult.Value);
            Assert.Equal(endereco.IdPessoa, enderecoRetornado.IdPessoa);
        }

        [Fact]
        public async Task CriarEndereco_Nulo_DeveRetornarStatusCode400()
        {
            // Act
            var resultado = await _controller.CreateEndereco(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task AtualizarEndereco_Valido_DeveRetornarStatusCode204()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            var endereco = new Endereco { IdPessoa = pessoaId, Logradouro = "Rua Atualizada" };

            _enderecoServiceMock.Setup(service => service.UpdateEnderecoAsync(endereco)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _controller.UpdateEndereco(pessoaId, endereco);

            // Assert
            Assert.IsType<NoContentResult>(resultado);
        }

        [Fact]
        public async Task AtualizarEndereco_IdsDivergentes_DeveRetornarStatusCode400()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            var endereco = new Endereco { IdPessoa = Guid.NewGuid(), Logradouro = "Rua Atualizada" };

            // Act
            var resultado = await _controller.UpdateEndereco(pessoaId, endereco);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }
    }
}
