using BACKEND.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NutricaoContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Conexao")
));

var app = builder.Build();

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
