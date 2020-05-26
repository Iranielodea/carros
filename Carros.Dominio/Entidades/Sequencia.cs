namespace Carros.Dominio.Entidades
{
    public class Sequencia : EntidadeBase
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public int? Valor { get; set; }
    }
}
