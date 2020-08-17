using Carros.Dominio.Entidades;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositoryEncontro : IRepositoryBase<Encontro>
    {
        IQueryable<EncontroConsulta> ListarPorEncontro(int numEncontro, string nomePessoa, int id);
    }
}
