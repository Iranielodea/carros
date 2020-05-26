using System.Collections;
using System.Collections.Generic;

namespace Carros.Dominio.Entidades
{
    public class Marca : EntidadeBase
    {
        public Marca()
        {
            Veiculos = new List<Veiculo>();
        }
        public string Descricao { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
