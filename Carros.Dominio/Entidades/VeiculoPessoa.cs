namespace Carros.Dominio.Entidades
{
    public class VeiculoPessoa : EntidadeBase
    {
        public VeiculoPessoa()
        {
            Pessoa = new PessoaBase();
            Veiculo = new Veiculo();
        }
        public int IdPessoa { get; set; }
        public int IdVeiculo { get; set; }
        public PessoaBase Pessoa { get; set; }
        public Veiculo Veiculo { get; set; }
    }

    public class VeiculoPessoaConsulta
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
    }
}
