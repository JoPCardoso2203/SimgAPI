using SimgAPI;
using Serilog;
using SimgAPI.Configuracao;
using SimgAPI.Infraestrutura.Mqtt;
using SimgAPI.Dominio.Interfaces;
using SimgAPI.Infraestrutura.Dados.Repositorios;
using SimgAPI.Dominio.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

InjecaoDependencia.AddInjecaoDependencia(builder.Services);
ConfiguracaoLogs.ConfiguraLogs(builder);

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();
