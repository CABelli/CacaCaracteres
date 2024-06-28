using CacaCaracteres.ContextoDB;
using CacaCaracteres.Repositorio;
using CacaCaracteres.Servicos;
using CacaCaracteres.ServicosCPF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IResumoTextoServico, ResumoTextoServico>();
builder.Services.AddScoped<ILivroTextoRepositorio, LivroTextoRepositorio>();
builder.Services.AddScoped<ILivroTextoServico, LivroTextoServico>();
builder.Services.AddScoped<IValidationCPF, ValidationCPF>();

IConfiguration configuration = builder.Configuration;
builder.Services.AddDbContext<AppDataBaseContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionDB"));
}  );

builder.Services.AddScoped<DbContext, AppDataBaseContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
