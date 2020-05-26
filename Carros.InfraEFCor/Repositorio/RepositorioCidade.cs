using Carros.Dominio.Entidades;
using Carros.InfraEFCor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor.Repositorio
{
    public class RepositorioCidade : RepositorioBase<Cidade>, IRepositorioCidade
    {
        public RepositorioCidade(Contexto contexto) : base(contexto)
        {
        }
    }
}
