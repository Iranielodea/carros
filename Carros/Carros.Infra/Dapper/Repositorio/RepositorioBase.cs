using Carros.Dominio.Interfaces;
using Dommel;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        IDbTransaction _transacao;
        IDbConnection _conexao;

        public RepositorioBase(IDbConnection conexao, IDbTransaction transaction)
        {
            _conexao = conexao;
            _transacao = transaction;
        }

        public virtual void Adicionar(ref TEntity entidade)
        {
            var id = _conexao.Insert(entidade, _transacao);
            entidade = RetornarPorId((int)id);
        }

        public virtual bool Alterar(TEntity entidade)
        {
            return _conexao.Update(entidade, _transacao);
        }

        public void BeginTransaction()
        {
            _transacao.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _transacao.Commit();
        }

        public void Deletar(TEntity entidade)
        {
            _conexao.Delete(entidade, _transacao);
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }

        public TEntity RetornarPorId(int id)
        {
            return _conexao.Get<TEntity>(id);
        }

        public IQueryable<TEntity> RetornarTodos()
        {
            return _conexao.GetAll<TEntity>().AsQueryable();
        }

        public void RollBack()
        {
            _transacao.Rollback();
        }

        protected string SequencialFB(string generator)
        {
            return "SELECT GEN_ID(" + generator + ", 0) FROM RDB$DATABASE";
        }

        void IRepositorioBase<TEntity>.Alterar(TEntity entidade)
        {
            _conexao.Update(entidade, _transacao);
        }
    }
}
