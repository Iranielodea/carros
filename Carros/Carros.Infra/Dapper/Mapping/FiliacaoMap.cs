using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class FiliacaoMap : DommelEntityMap<Filiacao>
    {
        public FiliacaoMap()
        {
            ToTable("FILIACAO");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.PessoaId).ToColumn("ID_PESSOA");
            Map(x => x.DataNascimento).ToColumn("DATANASC");
            Map(x => x.Nome).ToColumn("NOME");
        }
    }
}
