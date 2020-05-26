using System.ComponentModel.DataAnnotations.Schema;

namespace Carros.Dominio.Entidades
{
    public class Cidade : EntidadeBase
    {
        public Cidade()
        {
            UF = "RS";
        }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
    }
}
