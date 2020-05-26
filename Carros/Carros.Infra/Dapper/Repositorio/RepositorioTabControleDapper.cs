using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioTabControleDapper : RepositorioBase<TabControle>, IRepositorioTabControle
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioTabControleDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref TabControle entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new TabControle(), "TABCONTROLE", "ID");
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_tabControle"), null, _transaction).First();
        }

        public void ExecutarComando(string instrucaoSQL)
        {
            _conexao.Execute(instrucaoSQL);
        }
    }
}
