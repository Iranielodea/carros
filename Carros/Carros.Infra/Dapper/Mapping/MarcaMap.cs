using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class MarcaMap : DommelEntityMap<Marca>
    {
        public MarcaMap()
        {
            ToTable("MARCA");
            Map(x => x.Id).ToColumn("ID").IsKey();
        }
    }
}
