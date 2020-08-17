using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServiceContato : IServiceBase<Contato>
    {
        void Salvar(Contato contato);
        List<Contato> ObterPorPessoa(int idPessoa);
    }
}
