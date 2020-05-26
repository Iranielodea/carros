using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class CidadeMap : DommelEntityMap<Cidade>
    {
        public CidadeMap()
        {
            ToTable("CIDADE");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.Nome).ToColumn("DESCRICAO");
        }
    }
}
