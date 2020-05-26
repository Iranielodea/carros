namespace Carros.Dominio.Entidades
{
    public class CadEncontro : EntidadeBase
    {
        public CadEncontro()
        {
            EventoAtual = "N";
        }
        public string Descricao { get; set; }
        public int NumeroEncontro { get; set; }
        public string EventoAtual { get; set; }
    }
}
