using Carros.Dominio.Interfaces;
using System.Data;

namespace Carros.CrosPlataform
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        internal UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        IDbConnection _connection = null;
        IDbTransaction _transaction = null;

        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }
    }
}
