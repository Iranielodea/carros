using System.Linq;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoBase<T> where T : class
    {
        T RetornarPorId(int id);
        IQueryable<T> RetornarTodos();
        void Adicionar(ref T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
        void Dispose();
    }
}
