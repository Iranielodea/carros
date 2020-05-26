using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioContatoDapper : RepositorioBase<Contato>, IRepositorioContato
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioContatoDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Contato entity)
        {
            string instrucaoSQL = "INSERT INTO CONTATO(PESSOA_ID, TELEFONE, CELULAR, EMAIL, OBS)" 
                + " values (@PessoaId, @Telefone, @Celular, @Email, @Observacao)";
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_Contato"), null, _transaction).First();
        }
    }
}
