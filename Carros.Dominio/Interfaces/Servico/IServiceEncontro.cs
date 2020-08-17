using Carros.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServiceEncontro : IServiceBase<Encontro>
    {
        void Salvar(Encontro profissao);
        List<EncontroConsulta> ListarPorNome(string nome, int numEncontro, int id);
        void Imprimir(ImpressaoEncontro impressao, bool config = false);
        void Excluir(int id);
        Encontro ObterNumeroFicha(int idCliente, int numeroEncontro);
        IQueryable<EncontroConsulta> ListarPorEncontro(int numEncontro, string nomePessoa, int id);
        string ObterEncontroAtual();
    }
}
