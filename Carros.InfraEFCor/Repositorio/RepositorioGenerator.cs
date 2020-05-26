using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor.Repositorio
{
    public class RepositorioGenerator
    {
        private readonly Contexto _contexto;
        public RepositorioGenerator(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int RetornarId(string generator)
        {
            //var lista = _contexto.GeneratorSet.FromSql("SELECT GEN_ID(" + generator + ", 1) AS ID FROM RDB$DATABASE").ToList();
            var lista = _contexto.GeneratorSet.FromSql("SELECT GEN_ID(SEQ_MARCA, 1) AS ID FROM RDB$DATABASE").ToList();
            //var lista = _contexto.GeneratorSet.FromSql(string.Format("SELECT GEN_ID({0}, 1) AS ID FROM RDB$DATABASE",generator)).ToList();
            return lista.First().Id;
        }
    }
}
