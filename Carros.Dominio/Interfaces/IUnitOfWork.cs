using Carros.Dominio.Interfaces.Servico;
using System;

namespace Carros.Dominio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
    
        IServicoProfissao ServicoProfissao { get; }
        IServicoCidade ServicoCidade { get; }
        IServicoUsuario ServicoUsuario { get; }
        IServicoTabControle ServicoTabControle { get; }
        IServicoCadEncontro ServicoCadEncontro { get; }
        IServicoContato ServicoContato { get; }
        IServicoSequencia ServicoSequencia { get; }
        IServicoMarca ServicoMarca { get; }
        IServicoVeiculo ServicoVeiculo { get; }
        IServicoPessoa ServicoPessoa { get; }
        IServicoEncontro ServicoEncontro { get; }
        IServicoVeiculoPessoa ServicoVeiculoPessoa { get; }
        IServicoFiliacao ServicoFiliacao { get; }
        IServicoSQL ServicoSQL { get; }
    }
}
