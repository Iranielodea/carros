using Carros.Comum;
using Carros.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioPessoa : IRepositorioBase<Pessoa>
    {
        IQueryable<PessoaPesquisa> ListarCadastroSocios();
        IQueryable<PessoaPesquisa> ListarSociosExpositores();
        IQueryable<PessoaPesquisa> ListarExpositoresVisitantes();
        IQueryable<PessoaPesquisa> ListarTodosExpositores();
        IEnumerable<string> ListarEmails(int numeroEncontro, EnTipoExpositor tipo);
    }
}
