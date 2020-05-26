using Carros.Dominio.Interfaces;
using Carros.InfraEFCor2_1.Database.ContextoPrincipal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Carros.InfraEFCor2_1.Database.RepositorioEF
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

        public void Adicionar(ref T entidade)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
