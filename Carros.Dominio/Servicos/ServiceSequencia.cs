using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceSequencia : ServiceBase<Sequencia>, IServiceSequencia
    {
        private readonly IRepositorySequencia _repositorioSequencia;

        public ServiceSequencia(IRepositorySequencia repositorioSequencia)
            :base(repositorioSequencia)
        {
            _repositorioSequencia = repositorioSequencia;
        }

        public int IncrementarProximoNumero(string sigla, string descricao)
        {
            var model = _repositorioSequencia.RetornarTodos()
                .FirstOrDefault(x => x.Sigla == sigla);

            int valor = model.Valor.Value;
            if (model == null || model.Valor == null || model.Valor == 0)
            {
                model.Descricao = descricao;
                model.Sigla = sigla;
                model.Valor = 2;
                valor = 1;
                _repositorioSequencia.Adicionar(ref model);
            }
            else
            {
                model.Valor = model.Valor + 1;
                _repositorioSequencia.Alterar(model);
            }
            return valor;
        }

        public List<Sequencia> ListarTudo(int id = 0)
        {
            var dados = _repositorioSequencia.RetornarTodos();
            if (id > 0)
                dados = _repositorioSequencia.RetornarTodos().Where(x => x.Id == id);
            else
                dados = dados.OrderBy(x => x.Descricao);
            return dados.ToList();
        }

        public int ProximaFichaExpositorVisitante()
        {
            return IncrementarProximoNumero("FICH_VISITA", "Numero da Ficha do Visitante");
        }

        public int ProximaFichaSocioExpositor()
        {
            return IncrementarProximoNumero("FICH_PESSOA", "Numero da Ficha do Clube");
        }

        public int ProximaVisitanteMaisUm()
        {
            return BuscarProximo("FICH_VISITA");
        }

        public int ProximoSocioMaisUm()
        {
            return BuscarProximo("FICH_PESSOA");
        }

        public void Salvar(Sequencia model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");
            if (string.IsNullOrWhiteSpace(model.Sigla))
                throw new Exception("Informe a Sigla!");

            if (model.Id == 0)
                _repositorioSequencia.Adicionar(ref model);
            else
                _repositorioSequencia.Alterar(model);
        }

        private int BuscarProximo(string sigla)
        {
            var model = _repositorioSequencia.RetornarTodos()
                .FirstOrDefault(x => x.Sigla == sigla);
            return model.Valor.Value + 1;
        }
    }
}
