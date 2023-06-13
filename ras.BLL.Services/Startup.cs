using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ras.BLL.Services.Controllers;

namespace ras.BLL.Services
{

    public class Startup
{
    public Startup(IConfiguration configuration)
    {

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<ProjetoController>();
            builder.Services.AddTransient<PessoaController>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7214", "http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });


            var app = builder.Build();
            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();
            app.MapGet("/projetos", handler: ([FromServices] ProjetoController p) => p.GetProjetos().Result);
            app.MapGet("/projeto/{id}", handler: ([FromServices] ProjetoController p, int id) => p.GetProjetoById(id).Result);
            app.MapGet("/responsavel-projeto/{id}", handler: ([FromServices] ProjetoController p, int id) => p.GetResponsavelProjeto(id).Result);

            app.MapGet("/pessoas", handler: ([FromServices] PessoaController p) => p.GetPessoas().Result);
            app.MapGet("/pessoa/{id}", handler: ([FromServices] PessoaController p, int id) => p.GetPessoaById(id).Result);

            app.Run();
        }

    
} 
}
