using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioVeiculoDapper : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioVeiculoDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Veiculo entity)
        {
            string instrucaoSQL = "INSERT INTO VEICULO(ID_MARCA, MODELO, ANO, MARCA) values (@IdMarca, @Modelo, @Ano, @Marca)";
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_veiculo"), null, _transaction).First();
        }

        public IQueryable<VeiculoConsulta> RetornarConsulta()
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT V.ID, V.PLACA, V.MODELO, V.ANO, M.DESCRICAO AS DESCRICAOMARCA FROM Veiculo V");
            sb.AppendLine(" INNER JOIN MARCA M ON V.ID_MARCA = M.ID");

            return _conexao.Query<VeiculoConsulta>(sb.ToString(), null).AsQueryable();
        }
    }
}
