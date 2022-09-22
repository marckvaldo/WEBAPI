using Cart.App.Configuration;
using Cart.Business.interfaces;
using Cart.Business.Models;
using Cart.Data.Context;
using Cart.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string stringConexao = builder.Configuration.GetConnectionString("conexaoMySql");
builder.Services.AddDbContext<CartDbContext>(options =>
    {
        options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
    });

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; //desativa a validação por mode stats
});

builder.Services.ResolveDependencyConfig();

//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
