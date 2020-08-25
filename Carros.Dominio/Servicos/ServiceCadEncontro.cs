using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceCadEncontro : ServiceBase<CadEncontro>, IServiceCadEncontro
    {
        private readonly IRepositoryCadEncontro _repositorioCadEncontro;

        public ServiceCadEncontro(IRepositoryCadEncontro repositorioCadEncontro)
            :base(repositorioCadEncontro)
        {
            _repositorioCadEncontro = repositorioCadEncontro;
        }

        public List<CadEncontro> ListarPorNome(string nome, int id = 0)
        {
            if (id > 0)
                return _repositorioCadEncontro.RetornarTodos().Where(x => x.Id == id).ToList();
            else
                return _repositorioCadEncontro.RetornarTodos()
                    .Where(x => x.Descricao.Contains(nome.ToUpper())).OrderBy(x => x.Descricao).ToList();
        }

        public CadEncontro ObterNumeroEncontroAtual()
        {
            return _repositorioCadEncontro.RetornarTodos()
                .FirstOrDefault(x => x.EventoAtual == "S");
        }

        public void Salvar(CadEncontro model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe o Descrição!");

            if (model.NumeroEncontro <= 0)
                throw new Exception("Informe o Número do Encontro!");

            if (model.Id == 0)
                _repositorioCadEncontro.Adicionar(ref model);
            else
            {
                ValidarEventoAtual(model);

                _repositorioCadEncontro.Alterar(model);
            }

            GravarEventoAtual(model);
        }

        private void GravarEventoAtual(CadEncontro model)
        {
            if (model.EventoAtual == "S")
            {
                var lista = _repositorioCadEncontro.RetornarTodos().Where(x => x.Id != model.Id);
                foreach (var item in lista)
                {
                    item.EventoAtual = "N";
                    _repositorioCadEncontro.Alterar(item);
                }
            }
        }

        private void ValidarEventoAtual(CadEncontro model)
        {
            if (model.EventoAtual == "N")
            {
                if (!_repositorioCadEncontro.RetornarTodos().Any(x => x.EventoAtual == "S"
                    && x.Id != model.Id))
                {
                    throw new Exception("Não poderá desmarcar o evento atual. Escolha outro encontro e marque como evento atual");
                }
            }
        }
    }
}
