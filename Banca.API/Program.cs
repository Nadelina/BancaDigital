using Banca.Data.Data;
using Banca.Data.Repositories.Interfaces;
using Banca.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Banca.API.Handlers;
using Banca.API.Validators.Compra;
using FluentValidation.AspNetCore;
using FluentValidation;
using Banca.API.Validators.TitularTarjeta;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var urlCliente = builder.Configuration["UrlSettings:Cliente"];
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins(urlCliente).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(connectionString));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CrearCompraCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ActualizarTitularTarjetaCommandValidator>();

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddScoped<TitularTarjetaHandler>();
builder.Services.AddScoped<CompraHandler>();
builder.Services.AddScoped<ITitularTarjetaRepository, TitularTarjetaRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<SeedDb>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<SeedDb>();
    dbInitializer.SeedAsync().Wait();
}

app.Run();
