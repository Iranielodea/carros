using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class UsuarioMap : DommelEntityMap<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("USUARIO");
            Map(x => x.Id).ToColumn("ID").IsKey();
        }
    }
}
