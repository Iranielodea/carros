using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceFiliacao : ServiceBase<Filiacao>, IServiceFiliacao
    {
        private readonly IRepositoryFiliacao _repositorioFiliacao;

        public ServiceFiliacao(IRepositoryFiliacao repositorioFiliacao)
            : base(repositorioFiliacao)
        {
            _repositorioFiliacao = repositorioFiliacao;
        }

        public void Excluir(int id)
        {
            _repositorioFiliacao.Deletar(_repositorioFiliacao.RetornarPorId(id));
        }

        public List<Filiacao> ListarPorPessoa(int idPessoa)
        {
            return _repositorioFiliacao.RetornarTodos().Where(x => x.PessoaId == idPessoa).ToList();
        }

        public void Salvar(Filiacao filiacao)
        {
            if (string.IsNullOrWhiteSpace(filiacao.Nome))
                throw new Exception("Informe o Nome!");

            if (filiacao.Id == 0)
                _repositorioFiliacao.Adicionar(ref filiacao);
            else
                _repositorioFiliacao.Alterar(filiacao);
        }
    }
}
