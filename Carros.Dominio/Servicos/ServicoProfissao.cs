using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServicoProfissao : ServicoBase<Profissao>, IServicoProfissao
    {
        private readonly IRepositorioProfissao _repositorioProfissao;

        public ServicoProfissao(IRepositorioProfissao repositorioProfissao)
            :base(repositorioProfissao)
        {
            _repositorioProfissao = repositorioProfissao;
        }

        public void Excluir(int id)
        {
            _repositorioProfissao.Deletar(_repositorioProfissao.RetornarPorId(id));
        }

        public List<Profissao> ListarPorNome(string nome, int id = 0)
        {
            if (id > 0)
                return _repositorioProfissao.RetornarTodos().Where(x => x.Id == id).ToList();
            else
                return _repositorioProfissao.RetornarTodos()
                    .Where(x => x.Descricao.Contains(nome)).OrderBy(x => x.Descricao).ToList();
        }

        public void Salvar(Profissao model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe o Descrição!");

            if (model.Id == 0)
                _repositorioProfissao.Adicionar(ref model);
            else
                _repositorioProfissao.Alterar(model);
        }
    }
}
