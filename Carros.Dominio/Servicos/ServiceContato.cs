using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceContato : ServiceBase<Contato>, IServiceContato
    {
        private readonly IRepositoryContato _repositorioContato;

        public ServiceContato(IRepositoryContato repositorioContato)
            :base(repositorioContato)
        {
            _repositorioContato = repositorioContato;
        }

        public List<Contato> ObterPorPessoa(int idPessoa)
        {
            return _repositorioContato.RetornarTodos().Where(x => x.PessoaId == idPessoa).ToList();
        }

        public void Salvar(Contato model)
        {
            if (string.IsNullOrWhiteSpace(model.Celular) &&
                string.IsNullOrWhiteSpace(model.Email) &&
                string.IsNullOrWhiteSpace(model.Observacao) &&
                string.IsNullOrWhiteSpace(model.Telefone))
                throw new Exception("Não há nenhuma informação para salvar!");

            if (model.Id == 0)
                _repositorioContato.Adicionar(ref model);
            else
                _repositorioContato.Alterar(model);
        }
    }
}
