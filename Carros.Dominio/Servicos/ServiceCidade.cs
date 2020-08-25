using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceCidade : ServiceBase<Cidade>, IServiceCidade
    {
        private readonly IRepositoryCidade _repositorioCidade;

        public ServiceCidade(IRepositoryCidade repositorioCidade)
            :base(repositorioCidade)
        {
            _repositorioCidade = repositorioCidade;
        }

        public List<Cidade> ListarPorNome(string nome, int id = 0)
        {
            if (id > 0)
                return _repositorioCidade.RetornarTodos().Where(x => x.Id == id).ToList();
            else
                return _repositorioCidade.RetornarTodos()
                    .Where(x => x.Nome.Contains(nome.ToUpper())).OrderBy(x => x.Nome).ToList();
        }

        public void Salvar(Cidade model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            if (model.Id == 0)
                _repositorioCidade.Adicionar(ref model);
            else
                _repositorioCidade.Alterar(model);
        }
    }
}
