using System;

namespace Carros.Dominio.Entidades
{
    public class Pessoa: PessoaBase
    {
        public Pessoa()
        {
            Profissao = new Profissao();
        }
        public DateTime? DataNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string TipoSangue { get; set; }
        public string FatorRH { get; set; }
        public int? ProfissaoId { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeConjuge { get; set; }
        public Profissao Profissao { get; set; }
    }

    public class PessoaFiltro : FiltroBase
    {
    }

    public class PessoaPesquisa : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string RG { get; set; }
        public int? CodigoSocio { get; set; }
        public int? CodigoVisita { get; set; }
        public int? CodigoFicha { get; set; }
    }
}
