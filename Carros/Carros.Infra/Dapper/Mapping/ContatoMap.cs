using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class ContatoMap : DommelEntityMap<Contato>
    {
        public ContatoMap()
        {
            ToTable("CONTATO");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.PessoaId).ToColumn("PESSOA_ID");
            Map(x => x.Observacao).ToColumn("OBS");
        }
    }
}
