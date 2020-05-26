using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioUsuarioDapper : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioUsuarioDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Usuario entity)
        {
            string instrucaoSQL = "INSERT INTO USUARIO(NOME, SENHA) values (@Nome, @Senha)";
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_usuario"), null, _transaction).First();
        }
    }
}
