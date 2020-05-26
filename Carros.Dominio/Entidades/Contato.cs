namespace Carros.Dominio.Entidades
{
    public class Contato: EntidadeBase
    {
        public Contato()
        {
            Pessoa = new Pessoa();
        }
        public string Telefone { get; set; }
        public Pessoa Pessoa { get; set; }
        public string Observacao { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int PessoaId { get; set; }
    }
}
