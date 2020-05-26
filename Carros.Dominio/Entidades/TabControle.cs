using System;

namespace Carros.Dominio.Entidades
{
    public class TabControle :EntidadeBase
    {
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int? ValorInt { get; set; }
        public string ValorString { get; set; }
        public DateTime? ValorData { get; set; }
    }
}
