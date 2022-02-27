using ApplicationLogic.UseCases.KreirajPonudu;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using PonudaFpis.Validation;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PonudaDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.Scan(s => s.FromAssemblyOf<KreirajPonuduSlucajKoriscenja>()
.AddClasses()
.AsImplementedInterfaces()
.WithScopedLifetime());

builder.Services.Scan(s => s.FromAssemblyOf<PonudaDbContext>()
.AddClasses()
.AsImplementedInterfaces()
.WithScopedLifetime());

builder.Services.AddControllers()
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<KreirajPonuduValidacija>())
                .AddJsonOptions(j => j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
