using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Dapper;
using System.Linq;
using System.Text;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryEncontroDapper : RepositoryBase<Encontro>, IRepositoryEncontro
    {
        private readonly IUnitOfWork _uow;

        public RepositoryEncontroDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Encontro entity)
        {
            string instrucaoSQL = "INSERT INTO ENCONTRO(ID_PESSOA, NUM_ENCONTRO, TIPO_EXPOSITOR, NUM_FICHA, DATA) values (@PessoaId, @NumEncontro, @TipoExpositor, @NumeroFicha, @Data)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_encontro"), null, _uow.Transaction).First();
        }

        public IQueryable<EncontroConsulta> ListarPorEncontro(int numEncontro, string nomePessoa, int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT E.id, E.num_ficha as NumeroFicha, E.id_pessoa as IdPessoa, P.nome, P.CODIGO_SOCIO AS CodigoSocio, P.CODIGO_FICHA AS CodigoFicha, P.CODIGO_VISITA AS CodigoVisita,");
            sb.AppendLine(" IIF(E.tipo_expositor = 1, P.codigo_ficha, P.codigo_visita) as Codigo,");
            sb.AppendLine(" case e.tipo_expositor");
            sb.AppendLine(" when 1 then 'SOCIO'");
            sb.AppendLine(" when 2 then 'VISITANTE'");
            sb.AppendLine(" else");
            sb.AppendLine(" 'CAD_SOCIO'");
            sb.AppendLine(" end AS TIPOEXPOSITOR");
            sb.AppendLine(" from ENCONTRO E");
            sb.AppendLine(" inner JOIN PESSOA P ON E.id_pessoa = P.id");
            if (id > 0)
                sb.AppendLine(" WHERE E.ID = " + id);
            else
                sb.AppendLine(" WHERE P.NOME containing('" + nomePessoa.ToUpper() + "')");
            sb.AppendLine(" AND E.NUM_ENCONTRO = " + numEncontro);

            sb.AppendLine(" ORDER BY E.ID desc");
            return _uow.Connection.Query<EncontroConsulta>(sb.ToString(), null).AsQueryable();
        }
    }
}
