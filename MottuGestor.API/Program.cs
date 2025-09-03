using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MottuGestor.Application.UseCases;
using MottuGestor.Domain.Interfaces;
using MottuGestor.Infrastructure.Context;
using MottuGestor.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"] ?? "GestMottu API",
        Description = "API RESTful para gestão de motos com Clean Architecture e DDD",
        Contact = new OpenApiContact
        {
            Name = "Equipe GestMottu",
            Email = "contato@mottu.com.br"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        x.IncludeXmlComments(xmlPath);
    }


    builder.Services.AddDbContext<MottuGestorContext>(options =>
        options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IMotoRepository, MotoRepository>();
    builder.Services.AddScoped<IPatioRepository, PatioRepository>();
    builder.Services.AddScoped<MotoUseCase>();

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
});