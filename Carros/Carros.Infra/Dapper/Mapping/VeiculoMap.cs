using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class VeiculoMap : DommelEntityMap<Veiculo>
    {
        public VeiculoMap()
        {
            ToTable("VEICULO");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.IdMarca).ToColumn("ID_MARCA");
        }
    }
}
