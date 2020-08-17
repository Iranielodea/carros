using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using Carros.Dominio.Servicos;
using Carros.Infra.Dapper.Repositorio;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.CrosPlataform
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDalSession)).To(typeof(DalSession));

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork));
            Bind(typeof(IRepositoryCidade)).To(typeof(RepositoryCidadeDapper));
            Bind(typeof(IRepositoryProfissao)).To(typeof(RepositoryProfissaoDapper));
            Bind(typeof(IRepositoryUsuario)).To(typeof(RepositoryUsuarioDapper));
            Bind(typeof(IRepositoryTabControle)).To(typeof(RepositoryTabControleDapper));
            Bind(typeof(IRepositorySequencia)).To(typeof(RepositorySequenciaDapper));
            Bind(typeof(IRepositoryMarca)).To(typeof(RepositoryMarcaDapper));
            Bind(typeof(IRepositoryCadEncontro)).To(typeof(RepositoryCadEncontroDapper));
            Bind(typeof(IRepositoryContato)).To(typeof(RepositoryContatoDapper));
            Bind(typeof(IRepositoryVeiculo)).To(typeof(RepositoryVeiculoDapper));
            Bind(typeof(IRepositoryEncontro)).To(typeof(RepositoryEncontroDapper));
            Bind(typeof(IRepositoryPessoa)).To(typeof(RepositoryPessoaDapper));
            Bind(typeof(IRepositoryVeiculoPessoa)).To(typeof(RepositoryVeiculoPessoaDapper));

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind(typeof(IServiceCidade)).To(typeof(ServiceCidade));
            Bind(typeof(IServiceProfissao)).To(typeof(ServiceProfissao));
            Bind(typeof(IServiceUsuario)).To(typeof(ServiceUsuario));
            Bind(typeof(IServiceTabControle)).To(typeof(ServiceTabControle));
            Bind(typeof(IServiceSequencia)).To(typeof(ServiceSequencia));
            Bind(typeof(IServiceMarca)).To(typeof(ServiceMarca));
            Bind(typeof(IServiceCadEncontro)).To(typeof(ServiceCadEncontro));
            Bind(typeof(IServiceContato)).To(typeof(ServiceContato));
            Bind(typeof(IServiceVeiculo)).To(typeof(ServiceVeiculo));
            Bind(typeof(IServiceEncontro)).To(typeof(ServiceEncontro));
            Bind(typeof(IServicePessoa)).To(typeof(ServicePessoa));
            Bind(typeof(IServiceVeiculoPessoa)).To(typeof(ServiceVeiculoPessoa));

        }
    }
}
