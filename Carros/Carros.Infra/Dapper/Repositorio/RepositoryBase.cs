using Carros.Dominio.Interfaces;
using Dommel;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly  IUnitOfWork _uow;
        public RepositoryBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public virtual void Adicionar(ref TEntity entidade)
        {
            var id = _uow.Connection.Insert(entidade, _uow.Transaction);
            entidade = RetornarPorId((int)id);
        }

        public void Alterar(TEntity entidade)
        {
            _uow.Connection.Update(entidade, _uow.Transaction);
        }

        public void Deletar(TEntity entidade)
        {
            _uow.Connection.Delete(entidade, _uow.Transaction);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public TEntity RetornarPorId(int id)
        {
            return _uow.Connection.Get<TEntity>(id);
        }

        public IQueryable<TEntity> RetornarTodos()
        {
            return _uow.Connection.GetAll<TEntity>().AsQueryable();
        }

        public void RollBack()
        {
            _uow.Rollback();
        }

        protected string SequencialFB(string generator)
        {
            return "SELECT GEN_ID(" + generator + ", 0) FROM RDB$DATABASE";
        }
    }
}
