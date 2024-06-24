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
    public class DadosBancariosControllerTests
    {
        private readonly Mock<IDadosBancariosService> _dadosBancariosServiceMock;
        private readonly DadosBancariosController _controller;

        public DadosBancariosControllerTests()
        {
            _dadosBancariosServiceMock = new Mock<IDadosBancariosService>();
            _controller = new DadosBancariosController(_dadosBancariosServiceMock.Object);
        }

        [Fact]
        public async Task BuscarDadosBancariosPorIdPessoa_Existente_DeveRetornarStatusCode200()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            var dadosBancarios = new DadosBancarios { IdPessoa = pessoaId, Conta = "12345-6" };
            _dadosBancariosServiceMock.Setup(service => service.GetDadosBancariosByIdPessoa(pessoaId)).ReturnsAsync(dadosBancarios);

            // Act
            var resultado = await _controller.GetDadosBancariosByIdPessoa(pessoaId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            var dadosBancariosRetornados = Assert.IsType<DadosBancarios>(okResult.Value);
            Assert.Equal(pessoaId, dadosBancariosRetornados.IdPessoa);
        }

        [Fact]
        public async Task BuscarDadosBancariosPorIdPessoa_NaoEncontrado_DeveRetornarStatusCode404()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            _dadosBancariosServiceMock.Setup(service => service.GetDadosBancariosByIdPessoa(pessoaId)).ReturnsAsync((DadosBancarios)null);

            // Act
            var resultado = await _controller.GetDadosBancariosByIdPessoa(pessoaId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task CriarDadosBancarios_Valido_DeveRetornarStatusCode201()
        {
            // Arrange
            var dadosBancarios = new DadosBancarios { IdPessoa = Guid.NewGuid(), Conta = "12345-6" };

            // Act
            var resultado = await _controller.CreateDadosBancarios(dadosBancarios);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(resultado);
            var dadosBancariosRetornados = Assert.IsType<DadosBancarios>(createdAtActionResult.Value);
            Assert.Equal(dadosBancarios.IdPessoa, dadosBancariosRetornados.IdPessoa);
        }

        [Fact]
        public async Task CriarDadosBancarios_Nulo_DeveRetornarStatusCode400()
        {
            // Act
            var resultado = await _controller.CreateDadosBancarios(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task AtualizarDadosBancarios_Valido_DeveRetornarStatusCode204()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            var dadosBancarios = new DadosBancarios { IdPessoa = pessoaId, Conta = "12345-6" };

            _dadosBancariosServiceMock.Setup(service => service.UpdateDadosBancariosAsync(dadosBancarios)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _controller.UpdateDadosBancarios(pessoaId, dadosBancarios);

            // Assert
            Assert.IsType<NoContentResult>(resultado);
        }

        [Fact]
        public async Task AtualizarDadosBancarios_IdsDivergentes_DeveRetornarStatusCode400()
        {
            // Arrange
            var pessoaId = Guid.NewGuid();
            var dadosBancarios = new DadosBancarios { IdPessoa = Guid.NewGuid(), Conta = "12345-6" };

            // Act
            var resultado = await _controller.UpdateDadosBancarios(pessoaId, dadosBancarios);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }
    }
}
