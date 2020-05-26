using Carros.Dominio.Interfaces;
using Dapper;
using System.Data;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioSQLDapper : IRepositorioSQL
    {
        private IDbConnection _conexao;

        public RepositorioSQLDapper(IDbConnection conexao)
        {
            _conexao = conexao;
        }

        public void ExecutarSQL(string instrucaoSQL)
        {
            _conexao.Execute(instrucaoSQL, null, null);
        }
    }
}
