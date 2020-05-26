using System;

namespace Carros.Dominio.Entidades
{
    public class Encontro : EntidadeBase
    {
        public Encontro()
        {
            Encontros = new CadEncontro();
            Pessoa = new PessoaBase();
        }
        public int PessoaId { get; set; }
        public int NumEncontro { get; set; }
        public int TipoExpositor { get; set; }
        public int? NumeroFicha { get; set; }
        public CadEncontro Encontros { get; set; }
        public PessoaBase Pessoa { get; set; }
        public DateTime Data { get; set; }
    }

    public class EncontroConsulta
    {
        public int Id { get; set; }
        public int NumeroFicha { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string TipoExpositor { get; set; }
        public int IdPessoa { get; set; }
    }

    public class ImpressaoEncontro
    {
        public string Letra { get; set; }
        public string NomePessoa { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int NumeroFicha { get; set; }
    }
}
