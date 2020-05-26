using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioSequenciaDapper : RepositorioBase<Sequencia>, IRepositorioSequencia
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioSequenciaDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Sequencia entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Sequencia(), "SEQUENCIA", "ID");
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_sequencia"), null, _transaction).First();
        }
    }
}
