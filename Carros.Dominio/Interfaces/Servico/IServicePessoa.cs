using Carros.Comum;
using Carros.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicePessoa : IServiceBase<Pessoa>
    {
        List<PessoaPesquisa> ListarPorNome(string nome);
        List<string> ListarEmails(int numeroEncontro, EnTipoExpositor tipo);
        List<PessoaPesquisa> FiltrarSocios(PessoaFiltro pessoaFiltro, int id = 0);
        List<PessoaPesquisa> FiltrarCadastroSocios(PessoaFiltro filtro, int id = 0);
        List<PessoaPesquisa> FiltrarVisitantes(PessoaFiltro filtro, int id = 0);
        List<PessoaPesquisa> FiltrarTodos(PessoaFiltro filtro, int id = 0);
        List<PessoaPesquisa> FiltrarExpositores(PessoaFiltro filtro, int id = 0);
        Pessoa ObterPorCPF(string cpf, EnTipoExpositor enTipoExpositor);
        void Salvar(Pessoa model, EnTipoExpositor tipoExpositor);
        void Excluir(int id);
        Pessoa ObterPorSocio(int codigo);
        Pessoa ObterPorSocioVisitante(int codigo);
        Pessoa ObterPorVisitante(int codigo);
        int ObterNumeroFichar(int idPessoa);
    }
}
