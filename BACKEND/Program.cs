using BACKEND.Context;
using BACKEND.Interfaces;
using BACKEND.Repository;
using BACKEND.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INutricaoRepository, NutricaoRepository>();

builder.Services.AddScoped<INutricaoService, NutricaoService>();

builder.Services.AddDbContext<NutricaoContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Conexao")
).EnableSensitiveDataLogging());

var app = builder.Build();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
scope.ServiceProvider.GetService<NutricaoContext>().Database.Migrate();

app.UseCors(
    x => x.SetIsOriginAllowed(x => true)
    .AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod()
);

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
