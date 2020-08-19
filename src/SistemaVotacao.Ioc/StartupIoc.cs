using System;
using SistemaVotacao.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace SistemaVotacao.Ioc
{
    public static class StartupIoc
    {
         public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(configuration["ConnectionString"]));            
        }
    }
}
