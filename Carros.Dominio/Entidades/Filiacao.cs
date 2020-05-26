using System;

namespace Carros.Dominio.Entidades
{
    public class Filiacao: EntidadeBase
    {
        public Filiacao()
        {
            Pessoa = new PessoaBase();
        }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int PessoaId { get; set; }
        public PessoaBase Pessoa { get; set; }
    }
}
