using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoFiliacao : IServicoBase<Filiacao>
    {
        void Salvar(Filiacao profissao);
        List<Filiacao> ListarPorPessoa(int idPessoa);
        void Excluir(int id);
    }
}
