using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class TabControleMap : DommelEntityMap<TabControle>
    {
        public TabControleMap()
        {
            ToTable("TABCONTROLE");
            Map(x => x.Id).ToColumn("ID").IsKey();
        }
    }
}
