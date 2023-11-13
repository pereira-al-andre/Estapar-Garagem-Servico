using ETP.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using ETP.Application;
using ETP.Domain;
using ETP.Infra;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ETP.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Estapar 2023 - Teste Garagens",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Andr� Pereira",
            Email = "pereira.al.andre@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/almeidaandrep/")
        },
        Description = "Este � um projeto teste desenvolvido para o teste t�nico para a empresa Estapar."
    });

    // Adiciona informa��es de coment�rio dos m�todos do controller
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var conn = builder.Configuration.GetConnectionString("SqlServerDBContext");

builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddDbContext<SqlServerDBContext>(o => o.UseSqlServer(conn));


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
