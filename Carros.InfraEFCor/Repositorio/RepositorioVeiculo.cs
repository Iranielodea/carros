using Carros.Dominio.Entidades;
using Carros.InfraEFCor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carros.InfraEFCor.Repositorio
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo(Contexto contexto) : base(contexto)
        {
        }

        public IQueryable<VeiculoConsulta> RetornarConsulta()
        {
            var consulta = (from ve in Context.VeiculoSet
                            join ma in Context.MarcaSet on ve.IdMarca equals ma.Id
                            select new VeiculoConsulta
                            {
                                Ano = ve.Ano,
                                DescricaoMarca = ma.Descricao,
                                Id = ve.Id,
                                Modelo = ve.Modelo,
                                Placa = ve.Placa
                            });
            return consulta;
        }
    }
}
