using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Dapper;
using System.Linq;
using System.Text;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryVeiculoPessoaDapper : RepositoryBase<VeiculoPessoa>, IRepositoryVeiculoPessoa
    {
        private readonly IUnitOfWork _uow;
        public RepositoryVeiculoPessoaDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref VeiculoPessoa entity)
        {
            string instrucaoSQL = "INSERT INTO VEICULO_PESSOA(ID_PESSOA, ID_VEICULO) values (@IdPessoa, @IdVeiculo)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_veiculo_pessoa"), null, _uow.Transaction).First();
        }

        public IQueryable<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa)
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT VP.id, V.placa, V.modelo, V.ano, M.Descricao as Marca FROM VEICULO_PESSOA VP");
            sb.AppendLine(" INNER JOIN VEICULO V ON VP.id_veiculo = V.id");
            sb.AppendLine(" INNER JOIN MARCA M ON V.id_marca = M.id");
            sb.AppendLine(" WHERE VP.ID_PESSOA = " + idPessoa);
            return _uow.Connection.Query<VeiculoPessoaConsulta>(sb.ToString(), null).AsQueryable();
        }
    }
}
