using Carros.Dominio.Entidades;

namespace Carros.InfraEFCor.Interfaces
{
    public interface IRepositorioMarca : IRepositorioBase<Marca>
    {
        int Sequencial();
    }
}
