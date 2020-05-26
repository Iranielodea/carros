using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        T RetornarPorId(int id);
        IQueryable<T> RetornarTodos();
        void Adicionar(ref T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
        void BeginTransaction();
        void Commit();
        void RollBack();
        void Dispose();
    }
}
