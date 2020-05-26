using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carros.Infra.Dapper.Mapping;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Carros.CrosPlataform
{
    public class RegisterMappings
    { 
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CadEncontroMap());
                config.AddMap(new UsuarioMap());
                config.AddMap(new SequenciaMap());
                config.AddMap(new TabControleMap());
                config.AddMap(new ProfissaoMap());
                config.AddMap(new CidadeMap());
                config.AddMap(new MarcaMap());
                config.AddMap(new VeiculoMap());
                config.AddMap(new PessoaMap());
                config.AddMap(new ContatoMap());
                config.AddMap(new VeiculoPessoaMap());
                config.AddMap(new EncontroMap());
                config.AddMap(new FiliacaoMap());
                config.ForDommel();
            });
        }
    }
}
