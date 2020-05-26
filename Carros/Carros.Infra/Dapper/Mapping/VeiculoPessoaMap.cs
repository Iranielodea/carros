using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class VeiculoPessoaMap : DommelEntityMap<VeiculoPessoa>
    {
        public VeiculoPessoaMap()
        {
            ToTable("VEICULO_PESSOA");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.IdPessoa).ToColumn("ID_PESSOA");
            Map(x => x.IdVeiculo).ToColumn("ID_VEICULO");
        }
    }
}
