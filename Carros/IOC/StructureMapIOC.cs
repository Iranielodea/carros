using Carros.Dominio.Interfaces.Servico;
using Carros.Dominio.Servicos;
using Carros.InfraEFCor;
using Carros.InfraEFCor.Interfaces;
using Carros.InfraEFCor.Repositorio;
using StructureMap;
using ObjectFactory = StructureMap.ObjectFactory;

namespace Carros.IOC
{
    public static class StructureMapIOC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                x.For<IRepositorioMarca>().Use<RepositorioMarca>();
                x.For<ITransacao>().Use<TransacaoEF>();
                x.For<IRepositorioTabControle>().Use<RepositorioTabControle>();
                x.For<IRepositorioUsuario>().Use<RepositorioUsuario>();
                x.For<IRepositorioCadEncontro>().Use<RepositorioCadEncontro>();
                x.For<IRepositorioCidade>().Use<RepositorioCidade>();
                x.For<IRepositorioProfissao>().Use<RepositorioProfissao>();
                x.For<IRepositorioVeiculo>().Use<RepositorioVeiculo>();
                x.For<IRepositorioVeiculo>().Use<RepositorioVeiculo>();

                x.For(typeof(IServicoBase<>)).Use(typeof(ServicoBase<>));
                x.For(typeof(IServicoProfissao)).Use(typeof(ServicoProfissao));
                x.For(typeof(IServicoCidade)).Use(typeof(ServicoCidade));
                x.For(typeof(IServicoUsuario)).Use(typeof(ServicoUsuario));
                x.For(typeof(IServicoTabControle)).Use(typeof(ServicoTabControle));
                x.For(typeof(IServicoCadEncontro)).Use(typeof(ServicoCadEncontro));
                x.For(typeof(IServicoContato)).Use(typeof(ServicoContato));
                x.For(typeof(IServicoSequencia)).Use(typeof(ServicoSequencia));
                x.For(typeof(IServicoMarca)).Use(typeof(ServicoMarca));
                x.For(typeof(IServicoPessoa)).Use(typeof(ServicoPessoa));
                x.For(typeof(IServicoEncontro)).Use(typeof(ServicoEncontro));
                x.For(typeof(IServicoFiliacao)).Use(typeof(ServicoFiliacao));
                //x.For(typeof(IServicoSQL)).Use(typeof(ServicoSQL));

                x.For(typeof(ServicoSQL));
            });
            return ObjectFactory.Container;
        }
    }
}
