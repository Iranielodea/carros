using Carros.Dominio.Entidades;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioEncontro : IRepositorioBase<Encontro>
    {
        IQueryable<EncontroConsulta> ListarPorEncontro(int numEncontro, string nomePessoa, int id);
    }
}
