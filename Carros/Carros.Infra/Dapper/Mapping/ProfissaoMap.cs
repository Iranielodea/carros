using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class ProfissaoMap : DommelEntityMap<Profissao>
    {
        public ProfissaoMap()
        {
            ToTable("PROFISSAO");
            Map(x => x.Id).ToColumn("ID").IsKey();
        }
    }
}
