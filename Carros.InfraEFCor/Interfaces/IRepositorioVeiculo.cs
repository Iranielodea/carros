using Carros.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Carros.InfraEFCor.Interfaces
{
    public interface IRepositorioVeiculo : IRepositorioBase<Veiculo>
    {
        IQueryable<VeiculoConsulta> RetornarConsulta();
    }
}
