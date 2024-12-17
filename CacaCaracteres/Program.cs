using CacaCaracteres.ContextoDB;
using CacaCaracteres.FiltrosMensagem;
using CacaCaracteres.Repositorio;
using CacaCaracteres.Resources.Servicos;
using CacaCaracteres.Servicos;
using Microsoft.EntityFrameworkCore;
using ResourcesServicos = CacaCaracteres.Resources.Servicos;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var KeyVaultGlobalCultureLanguage = builder.Configuration.GetRequiredSection("KeyVault:KeyVaultGlobalCultureLanguage");
Resource.Culture = new System.Globalization.CultureInfo(KeyVaultGlobalCultureLanguage.Value);
ResourcesServicos.Resource.Culture = new System.Globalization.CultureInfo(KeyVaultGlobalCultureLanguage.Value);

// Add services to the container.

builder.Services.AddScoped<IResumoTextoServico, ResumoTextoServico>();
builder.Services.AddScoped<ILivroTextoRepositorio, LivroTextoRepositorio>();
builder.Services.AddScoped<ILivroTextoServico, LivroTextoServico>();
builder.Services.AddScoped<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddScoped<IAutorServico, AutorServico>();

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
