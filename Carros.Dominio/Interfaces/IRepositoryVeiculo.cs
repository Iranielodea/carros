using Carros.Dominio.Entidades;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositoryVeiculo : IRepositoryBase<Veiculo>
    {
        IQueryable<VeiculoConsulta> RetornarConsulta();
    }
}
