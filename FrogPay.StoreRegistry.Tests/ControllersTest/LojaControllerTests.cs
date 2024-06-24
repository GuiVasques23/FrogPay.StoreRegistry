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
    public class LojaControllerTests
    {
        private readonly Mock<ILojaService> _lojaServiceMock;
        private readonly LojaController _controller;

        public LojaControllerTests()
        {
            _lojaServiceMock = new Mock<ILojaService>();
            _controller = new LojaController(_lojaServiceMock.Object);
        }

        [Fact]
        public async Task BuscarLojaPorId_Existente_DeveRetornarStatusCode200()
        {
            // Arrange
            var lojaId = Guid.NewGuid();
            var loja = new Loja { Id = lojaId, Nome = "Loja Teste" };
            _lojaServiceMock.Setup(service => service.GetLojaByIdAsync(lojaId)).ReturnsAsync(loja);

            // Act
            var resultado = await _controller.GetLojaById(lojaId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            var lojaRetornada = Assert.IsType<Loja>(okResult.Value);
            Assert.Equal(lojaId, lojaRetornada.Id);
        }

        [Fact]
        public async Task BuscarLojaPorId_NaoEncontrada_DeveRetornarStatusCode404()
        {
            // Arrange
            var lojaId = Guid.NewGuid();
            _lojaServiceMock.Setup(service => service.GetLojaByIdAsync(lojaId)).ReturnsAsync((Loja)null);

            // Act
            var resultado = await _controller.GetLojaById(lojaId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task CriarLoja_Valida_DeveRetornarStatusCode201()
        {
            // Arrange
            var loja = new Loja { Id = Guid.NewGuid(), Nome = "Nova Loja", IdPessoa = Guid.NewGuid(), RazaoSocial = "Razao Social", Cnpj = "12345678901234", DataAbertura = DateOnly.FromDateTime(DateTime.Now) };

            // Act
            var resultado = await _controller.CreateLoja(loja);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(resultado);
            var lojaRetornada = Assert.IsType<Loja>(createdAtActionResult.Value);
            Assert.Equal(loja.Id, lojaRetornada.Id);
        }

        [Fact]
        public async Task CriarLoja_Nula_DeveRetornarStatusCode400()
        {
            // Act
            var resultado = await _controller.CreateLoja(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task AtualizarLoja_Valida_DeveRetornarStatusCode204()
        {
            // Arrange
            var lojaId = Guid.NewGuid();
            var loja = new Loja { Id = lojaId, Nome = "Loja Atualizada", IdPessoa = Guid.NewGuid(), RazaoSocial = "Razao Social Atualizada", Cnpj = "12345678901234", DataAbertura = DateOnly.FromDateTime(DateTime.Now) };

            _lojaServiceMock.Setup(service => service.UpdateLojaAsync(loja)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _controller.UpdateLoja(lojaId, loja);

            // Assert
            Assert.IsType<NoContentResult>(resultado);
        }

        [Fact]
        public async Task AtualizarLoja_IdsDivergentes_DeveRetornarStatusCode400()
        {
            // Arrange
            var lojaId = Guid.NewGuid();
            var loja = new Loja { Id = Guid.NewGuid(), Nome = "Loja Atualizada", IdPessoa = Guid.NewGuid(), RazaoSocial = "Razao Social Atualizada", Cnpj = "12345678901234", DataAbertura = DateOnly.FromDateTime(DateTime.Now) };

            // Act
            var resultado = await _controller.UpdateLoja(lojaId, loja);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }
    }
}
