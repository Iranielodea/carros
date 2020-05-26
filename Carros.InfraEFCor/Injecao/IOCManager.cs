using Carros.InfraEFCor.Interfaces;
using Carros.InfraEFCor.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor.Injecao
{
    public class IOCManager
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<Contexto>();
            services.AddScoped<ITransacao, TransacaoEF>();
            services.AddScoped<IRepositorioMarca, RepositorioMarca>();
            //services.AddScoped<IRepositorioCidade, RepositorioCidadeEF>();
            //services.AddScoped<IRepositorioCidade, RepositorioCidadeEF>();
            //services.AddScoped<IRepositorioEstado, RepositorioEstadoEF>();
            //services.AddScoped<IRepositorioPais, RepositorioPaisEF>();
            //services.AddScoped<IRepositorioEndereco, RepositorioEnderecoEF>();
            //services.AddScoped<IRepositorioEmpresaEndereco, RepositorioEmpresaEnderecoEF>();
            //services.AddScoped<IRepositorioEmpresa, RepositorioEmpresaEF>();
            //services.AddScoped<IRepositorioEmpresaDocumento, RepositorioEmpresaDocumentoEF>();
        }
    }
}
