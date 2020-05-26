using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioFiliacaoDapper : RepositorioBase<Filiacao>, IRepositorioFiliacao
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioFiliacaoDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Filiacao entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Filiacao(), "FILIACAO", "ID");
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_filiacao"), null, _transaction).First();
        }
    }
}
