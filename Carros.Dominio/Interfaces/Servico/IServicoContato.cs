using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoContato : IServicoBase<Contato>
    {
        void Salvar(Contato contato);
        List<Contato> ObterPorPessoa(int idPessoa);
    }
}
