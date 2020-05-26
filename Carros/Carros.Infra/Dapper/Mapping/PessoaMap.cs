using Carros.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;

namespace Carros.Infra.Dapper.Mapping
{
    public class PessoaMap : DommelEntityMap<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("PESSOA");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.CidadeId).ToColumn("ID_CIDADE");
            Map(x => x.TipoSangue).ToColumn("TIPO_SANGUE");
            Map(x => x.FatorRH).ToColumn("FATOR_RH");
            Map(x => x.ProfissaoId).ToColumn("ID_PROFISSAO");
            Map(x => x.CodigoSocio).ToColumn("CODIGO_SOCIO");
            Map(x => x.CodigoFicha).ToColumn("CODIGO_FICHA");
            Map(x => x.CodigoVisita).ToColumn("CODIGO_VISITA");
            Map(x => x.DataCadastro).ToColumn("DATA_CADASTRO");
            Map(x => x.DataNascimento).ToColumn("DATA_NASC");
            Map(x => x.NomePai).ToColumn("PAI");
            Map(x => x.NomeMae).ToColumn("MAE");
            Map(x => x.NomeEmpresa).ToColumn("EMPRESA");
            Map(x => x.NomeConjuge).ToColumn("CONJUGE");
            Map(x => x.CPF).ToColumn("CPF");
            Map(x => x.Codigo).Ignore();
        }
    }
}
