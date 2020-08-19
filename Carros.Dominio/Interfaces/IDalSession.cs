using Carros.Dominio.Interfaces.Servico;

namespace Carros.Dominio.Interfaces
{
    public interface IDalSession
    {
        IUnitOfWork UnitOfWork { get; }
        IServiceCidade ServiceCidade { get; }
        IServiceProfissao ServiceProfissao { get; }
        IServiceUsuario ServiceUsuario { get; }
        IServiceTabControle ServiceTabControle { get; }
        IServiceSequencia ServiceSequencia { get; }
        IServiceMarca ServiceMarca { get; }
        IServiceCadEncontro ServiceCadEncontro { get; }
        IServiceContato ServiceContato { get; }
        IServiceVeiculo ServiceVeiculo { get; }
        IServiceEncontro ServiceEncontro { get; }
        IServicePessoa ServicePessoa { get; }
        IServiceVeiculoPessoa ServiceVeiculoPessoa { get; }
        IServiceFiliacao ServiceFiliacao { get; }
        IServiceSQL ServiceSQL { get; }

        void Dispose();
    }
}
