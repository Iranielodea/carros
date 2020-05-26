using Carros.Dominio.Entidades;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioVeiculo : IRepositorioBase<Veiculo>
    {
        IQueryable<VeiculoConsulta> RetornarConsulta();
    }
}
