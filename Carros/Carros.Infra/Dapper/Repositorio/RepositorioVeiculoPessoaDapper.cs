using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioVeiculoPessoaDapper : RepositorioBase<VeiculoPessoa>, IRepositorioVeiculoPessoa
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioVeiculoPessoaDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref VeiculoPessoa entity)
        {
            string instrucaoSQL = "INSERT INTO VEICULO_PESSOA(ID_PESSOA, ID_VEICULO) values (@IdPessoa, @IdVeiculo)";
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_veiculo_pessoa"), null, _transaction).First();
        }

        public IQueryable<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa)
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT VP.id, V.placa, V.modelo, V.ano, M.Descricao as Marca FROM VEICULO_PESSOA VP");
            sb.AppendLine(" INNER JOIN VEICULO V ON VP.id_veiculo = V.id");
            sb.AppendLine(" INNER JOIN MARCA M ON V.id_marca = M.id");
            sb.AppendLine(" WHERE VP.ID_PESSOA = " + idPessoa);
            return _conexao.Query<VeiculoPessoaConsulta>(sb.ToString(), null).AsQueryable();
        }
    }
}
