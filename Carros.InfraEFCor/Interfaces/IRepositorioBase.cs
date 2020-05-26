using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        T RetornarPorId(int id);
        IQueryable<T> RetornarTodos();
        void Adicionar(T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
        void Salvar(T entidade, int id = 0);
        void Commit();
    }
}
