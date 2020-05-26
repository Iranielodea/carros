using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class EncontroMap : DommelEntityMap<Encontro>
    {
        public EncontroMap()
        {
            ToTable("ENCONTRO");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.PessoaId).ToColumn("ID_PESSOA");
            Map(x => x.NumEncontro).ToColumn("NUM_ENCONTRO");
            Map(x => x.TipoExpositor).ToColumn("TIPO_EXPOSITOR");
            Map(x => x.NumeroFicha).ToColumn("NUM_FICHA");
        }
    }
}
