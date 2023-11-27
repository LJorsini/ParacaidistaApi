using Microsoft.EntityFrameworkCore;
using ParacaApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/* builder.Services.AddDbContext<ParacaContext>(opt =>
    opt.UseInMemoryDatabase("Paracaidista")); */
    builder.Services.AddDbContext<ParacaContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ParacaContext") 
        ?? throw new InvalidOperationException("Connection string 'ParacaContext' not found.")));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
