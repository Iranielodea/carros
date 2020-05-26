using Carros.Dominio.Entidades;
using Carros.InfraEFCor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor.Repositorio
{
    public class RepositorioCadEncontro : RepositorioBase<CadEncontro>, IRepositorioCadEncontro
    {
        public RepositorioCadEncontro(Contexto contexto) : base(contexto)
        {
        }
    }
}
