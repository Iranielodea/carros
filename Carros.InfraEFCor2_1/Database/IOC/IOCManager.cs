using Carros.Dominio.Interfaces;
using Carros.InfraEFCor2_1.Database.ContextoPrincipal;
using Carros.InfraEFCor2_1.Database.RepositorioEF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor2_1.Database.IOC
{
    public class IOCManager
    {
        public static void Register(string connectionString, IServiceCollection services)
        {
            //services.AddDbContext<Contexto>(options =>
            //    options.UseMySql(connectionString).UseLazyLoadingProxies());
            //services.AddDbContext<Contexto>(options =>
            //    options.UseMySql(connectionString).UseLazyLoadingProxies());

            services.AddScoped<IRepositorioMarca, RepositorioMarca>();
            //services.AddScoped<ITransacao, Transacao>();
        }
    }
}
