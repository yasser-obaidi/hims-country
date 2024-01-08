using HimsCountry.Data;
using HimsCountry.Data.Repo;
using HimsCountry.Services;
using HimsCurrency.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<Context>(opt => opt.UseMySQL(
    connStr
  ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<HimsCurrencyRepo>();
builder.Services.AddScoped<HimsCurrencyService>();
builder.Services.AddScoped<HimsCountryRepo>();
builder.Services.AddScoped<HimsCountryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
