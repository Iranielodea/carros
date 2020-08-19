using Carros.Dominio.Interfaces;
using Dapper;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorySQLDapper : IRepositorySQL
    {
        private IUnitOfWork _uow;

        public RepositorySQLDapper(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void ExecutarSQL(string instrucaoSQL)
        {
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }
    }
}
