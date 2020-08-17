using Carros.Dominio.Entidades;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositoryTabControle : IRepositoryBase<TabControle>
    {
        void ExecutarComando(string instrucaoSQL);
    }
}
