using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoProfissao : IServicoBase<Profissao>
    {
        void Salvar(Profissao profissao);
        List<Profissao> ListarPorNome(string nome, int id = 0);
        void Excluir(int id);
    }
}
