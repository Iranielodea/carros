using Carros.Dominio.Entidades;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioTabControle : IRepositorioBase<TabControle>
    {
        void ExecutarComando(string instrucaoSQL);
    }
}
