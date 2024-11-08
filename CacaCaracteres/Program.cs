using CacaCaracteres.ContextoDB;
using CacaCaracteres.FiltrosMensagem;
using CacaCaracteres.Repositorio;
using CacaCaracteres.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IResumoTextoServico, ResumoTextoServico>();
builder.Services.AddScoped<ILivroTextoRepositorio, LivroTextoRepositorio>();
builder.Services.AddScoped<ILivroTextoServico, LivroTextoServico>();

IConfiguration configuration = builder.Configuration;
builder.Services.AddDbContext<AppDataBaseContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionDB"));
}  );

builder.Services.AddScoped<DbContext, AppDataBaseContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(MessageOrExceptionFilter)));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
