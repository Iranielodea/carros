using Carros.Dominio.Entidades;
using Carros.InfraEFCor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor.Repositorio
{
    public class RepositorioProfissao : RepositorioBase<Profissao>, IRepositorioProfissao
    {
        public RepositorioProfissao(Contexto contexto) : base(contexto)
        {
        }
    }
}
