using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioProfissaoDapper : RepositorioBase<Profissao>, IRepositorioProfissao
    {
        private IDbConnection _conexao;
        private readonly IDbTransaction _transaction;

        public RepositorioProfissaoDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Profissao entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Profissao(), "PROFISSAO", "ID");
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_Profissao"), null, _transaction).First();
        }
    }
}
