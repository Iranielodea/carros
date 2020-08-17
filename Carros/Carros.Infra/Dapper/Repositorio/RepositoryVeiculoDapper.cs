using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Dapper;
using System.Linq;
using System.Text;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryVeiculoDapper : RepositoryBase<Veiculo>, IRepositoryVeiculo
    {
        private readonly IUnitOfWork _uow;
        public RepositoryVeiculoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Veiculo entity)
        {
            string instrucaoSQL = "INSERT INTO VEICULO(ID_MARCA, MODELO, ANO, MARCA) values (@IdMarca, @Modelo, @Ano, @Marca)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_veiculo"), null, _uow.Transaction).First();
        }

        public IQueryable<VeiculoConsulta> RetornarConsulta()
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT V.ID, V.PLACA, V.MODELO, V.ANO, M.DESCRICAO AS DESCRICAOMARCA FROM Veiculo V");
            sb.AppendLine(" INNER JOIN MARCA M ON V.ID_MARCA = M.ID");

            return _uow.Connection.Query<VeiculoConsulta>(sb.ToString(), null).AsQueryable();
        }
    }
}
