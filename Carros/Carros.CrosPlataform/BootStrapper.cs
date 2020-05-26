using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using Carros.Dominio.Servicos;
using Carros.Infra.Dapper.Repositorio;
using FirebirdSql.Data.FirebirdClient;
using StructureMap;
using System.Data;

namespace Carros.CrosPlataform
{
    public static class BootStrapper
    {
        public static void ConfigureStructerMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IDbConnection>().Use<FbConnection>();
                x.For<IDbTransaction>().Use<FbTransaction>();
                x.For(typeof(IRepositorioBase<>)).Use(typeof(RepositorioBase<>));
                x.For<IUnitOfWork>().Use<UnitOfWork>();

                x.For(typeof(IRepositorioProfissao)).Use(typeof(RepositorioProfissaoDapper));
                x.For(typeof(IRepositorioCidade)).Use(typeof(RepositorioCidadeDapper));
                x.For(typeof(IRepositorioUsuario)).Use(typeof(RepositorioUsuarioDapper));
                x.For(typeof(IRepositorioTabControle)).Use(typeof(RepositorioTabControleDapper));
                x.For(typeof(IRepositorioCadEncontro)).Use(typeof(RepositorioCadEncontroDapper));
                x.For(typeof(IRepositorioContato)).Use(typeof(RepositorioContatoDapper));
                x.For(typeof(IRepositorioSequencia)).Use(typeof(RepositorioSequenciaDapper));
                x.For(typeof(IRepositorioMarca)).Use(typeof(RepositorioMarcaDapper));
                x.For(typeof(IRepositorioVeiculo)).Use(typeof(RepositorioVeiculoDapper));
                x.For(typeof(IRepositorioPessoa)).Use(typeof(RepositorioPessoaDapper));
                x.For(typeof(IRepositorioEncontro)).Use(typeof(RepositorioEncontroDapper));
                x.For(typeof(IRepositorioVeiculoPessoa)).Use(typeof(RepositorioVeiculoPessoaDapper));
                x.For(typeof(IRepositorioFiliacao)).Use(typeof(RepositorioFiliacaoDapper));
                x.For(typeof(IRepositorioSQL)).Use(typeof(RepositorioSQLDapper));

                //=======================================================================
                // SERVICOS
                //=======================================================================

                x.For(typeof(IServicoBase<>)).Use(typeof(ServicoBase<>));
                x.For(typeof(IServicoProfissao)).Use(typeof(ServicoProfissao));
                x.For(typeof(IServicoCidade)).Use(typeof(ServicoCidade));
                x.For(typeof(IServicoUsuario)).Use(typeof(ServicoUsuario));
                x.For(typeof(IServicoTabControle)).Use(typeof(ServicoTabControle));
                x.For(typeof(IServicoCadEncontro)).Use(typeof(ServicoCadEncontro));
                x.For(typeof(IServicoContato)).Use(typeof(ServicoContato));
                x.For(typeof(IServicoSequencia)).Use(typeof(ServicoSequencia));
                x.For(typeof(IServicoMarca)).Use(typeof(ServicoMarca));
                x.For(typeof(IServicoVeiculo)).Use(typeof(ServicoVeiculo));
                x.For(typeof(IServicoPessoa)).Use(typeof(ServicoPessoa));
                x.For(typeof(IServicoEncontro)).Use(typeof(ServicoEncontro));
                x.For(typeof(IServicoVeiculoPessoa)).Use(typeof(ServicoVeiculoPessoa));
                x.For(typeof(IServicoFiliacao)).Use(typeof(ServicoFiliacao));
                x.For(typeof(IServicoSQL)).Use(typeof(ServicoSQL));
                //x.For(typeof(ServicoSQL));
            });
        }
    }
}
