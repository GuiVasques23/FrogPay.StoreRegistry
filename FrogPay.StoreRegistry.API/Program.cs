using FluentValidation.AspNetCore;
using FluentValidation;
using FrogPay.StoreRegistry.Domain.Core;
using FrogPay.StoreRegistry.Infra.Context;
using FrogPay.StoreRegistry.Infra.Interfaces;
using FrogPay.StoreRegistry.Infra.Repositories;
using FrogPay.StoreRegistry.Services.Interfaces;
using FrogPay.StoreRegistry.Services.Services;
using FrogPay.StoreRegistry.Services.Validators;
using Microsoft.EntityFrameworkCore;
using FrogPay.StoreRegistry.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<StoreRegistryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IDadosBancariosRepository, DadosBancariosRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();

// Services
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<ILojaService, LojaService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IDadosBancariosService, DadosBancariosService>();

// FluentValidation
builder.Services.AddTransient<IValidator<Pessoa>, PessoaValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "FrogPay Store Registry API",
        Description = "API para o registro de lojas no FrogPay"
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FrogPay Store Registry API v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
