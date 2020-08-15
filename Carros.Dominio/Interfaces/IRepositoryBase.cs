using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T RetornarPorId(int id);
        IQueryable<T> RetornarTodos();
        void Adicionar(ref T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
        void Dispose();
    }
}
