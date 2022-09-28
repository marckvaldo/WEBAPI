using Cart.App.Configuration;
using Cart.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexao mysql
string stringConexao = builder.Configuration.GetConnectionString("conexaoMySql");
builder.Services.AddDbContext<CartDbContext>(options =>
{
    options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
});

//Identity
builder.Services.addIdentity(builder.Configuration);

//autoMap
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

//desativa a validação por mode stats para o customer result 
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; 
});

//Injeção de dependecy
builder.Services.ResolveDependencyConfig();


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
