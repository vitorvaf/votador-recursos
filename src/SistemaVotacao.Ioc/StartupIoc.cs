using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVotacao.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using SistemaVotacao.Dominio._Base;
using SistemaVotacao.Dados.Repositorios;
using SistemaVotacao.Dominio.Recursos;
using SistemaVotacao.Dominio.Funcionarios;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                 (options => options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=password"));

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(IRecursoRepositorio), typeof(RecursoRepositorio));
            services.AddScoped(typeof(IFuncionarioRepositorio), typeof(FuncionarioRepositorio));
            services.AddScoped(typeof(IVotoRepositorio), typeof(VotoRepositorio));
            services.AddScoped<ArmazenadorDeRecurso>();
            services.AddScoped<ArmazenadorDeFuncionario>();
            services.AddScoped<ArmazenadorDeVotos>();

        }

    }

}