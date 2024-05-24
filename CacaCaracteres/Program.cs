using CacaCaracteres.ContextoDB;
using CacaCaracteres.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IResumoTextoServico, ResumoTextoServico>();

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
