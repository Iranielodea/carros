using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor2_1.Database
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = @"database=127.0.0.1/3050:C:\Projetos\DotNet\Carros\Banco\VEICULO.FDB; user=sysdba; password=rota11";
            IOC.IOCManager.Register(connectionString, services);
        }
    }
}
