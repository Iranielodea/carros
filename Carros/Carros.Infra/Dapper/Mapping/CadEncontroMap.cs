using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class CadEncontroMap : DommelEntityMap<CadEncontro>
    {
        public CadEncontroMap()
        {
            ToTable("CAD_ENCONTRO");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.Descricao).ToColumn("DESCRICAO");
            Map(x => x.NumeroEncontro).ToColumn("NUM_ENCONTRO");
            Map(x => x.EventoAtual).ToColumn("EVENTO_ATUAL");
        }
    }
}
