using System;
using Carros.Dominio.ValueObject;

namespace Carros.Dominio.Entidades
{
    public class PessoaBase : EntidadeBase
    {
        public PessoaBase()
        {
            Cidade = new Cidade();
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int? CidadeId { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? CodigoSocio { get; set; }
        public int? CodigoVisita { get; set; }
        public int? CodigoFicha { get; set; }
        public Cidade Cidade { get; set; }
    }

    public class FiltroBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string NomeCidade { get; set; }
        public string Telefone { get; set; }
        public string UF { get; set; }
    }
}
