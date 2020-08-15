using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioCidadeDapper : RepositorioBase<Cidade>, IRepositorioCidade
    {
        private IDbConnection _conexao;
        private readonly IDbTransaction _transaction;

        public RepositorioCidadeDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Cidade entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = Dados.Inserir(new Cidade(), "CIDADE", "ID");
            string instrucaoSQL = "INSERT INTO CIDADE(DESCRICAO, CEP, UF) values (@Nome, @CEP, @UF)";
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_cidade"), null, _transaction).First();
        }
    }
}
