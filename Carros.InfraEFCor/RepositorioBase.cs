using Carros.InfraEFCor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly Contexto Context;

        public RepositorioBase(Contexto contexto)
        {
            //_contexto = new Contexto();
            Context = contexto;
        }

        public void Adicionar(T entidade)
        {
            Context.Add(entidade);
        }

        public void Alterar(T entidade)
        {
            Context.Attach(entidade);
            Context.Entry(entidade).State = EntityState.Modified;
        }

        public void Deletar(T entidade)
        {
            Context.Remove(entidade);
        }

        public T RetornarPorId(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> RetornarTodos()
        {
            return Context.Set<T>();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Salvar(T entidade, int id = 0)
        {
            if (id == 0)
                Adicionar(entidade);
            else
                Alterar(entidade);
        }
    }
}
