using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class SequenciaMap : DommelEntityMap<Sequencia>
    {
        public SequenciaMap()
        {
            ToTable("SEQUENCIA");
            Map(x => x.Id).ToColumn("ID").IsKey();
        }
    }
}
