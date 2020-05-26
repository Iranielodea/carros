namespace Carros.Dominio.Entidades
{
    public class Veiculo : EntidadeBase
    {
        public Veiculo()
        {
            Marca = new Marca();
        }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public Marca Marca { get; set; }
        public int IdMarca { get; set; }
    }

    public class VeiculoConsulta
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string DescricaoMarca { get; set; }
    }

    public class VeiculoFiltro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int idMarca { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string DescMarca { get; set; }
    }
}
