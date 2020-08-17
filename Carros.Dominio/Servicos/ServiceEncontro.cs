using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Carros.Comum;

namespace Carros.Dominio.Servicos
{
    public class ServiceEncontro : ServiceBase<Encontro>, IServiceEncontro
    {
        private readonly IRepositoryEncontro _repositorioEncontro;
        private IDalSession _session;

        public ServiceEncontro(IRepositoryEncontro repositorioEncontro, IDalSession session)
            : base(repositorioEncontro)
        {
            _repositorioEncontro = repositorioEncontro;
            _session = session;
        }

        public void Excluir(int id)
        {
            if (id > 0)
                _repositorioEncontro.Deletar(_repositorioEncontro.RetornarPorId(id));
        }

        public void Imprimir(ImpressaoEncontro impressao, bool config = false)
        {
            string imp = JsonConvert.SerializeObject(impressao);
            string configurar = "";
            if (config)
                configurar = " -conf";

            using (var arq = new ArquivoTexto("impressao.txt"))
            {
                arq.Escrever(imp);
            }
            System.Diagnostics.Process.Start("Impressao.exe", configurar);
        }

        public IQueryable<EncontroConsulta> ListarPorEncontro(int numEncontro, string nomePessoa, int id)
        {
            return _repositorioEncontro.ListarPorEncontro(numEncontro, nomePessoa, id);
        }

        public List<EncontroConsulta> ListarPorNome(string nome, int numEncontro, int id)
        {
            return _repositorioEncontro.ListarPorEncontro(numEncontro, nome, id).ToList();
        }

        public string ObterEncontroAtual()
        {
            return _session.ServiceCadEncontro.RetornarTodos().FirstOrDefault(x => x.EventoAtual == "S").NumeroEncontro.ToString();
        }

        public Encontro ObterNumeroFicha(int idCliente, int numeroEncontro)
        {
            return _repositorioEncontro.RetornarTodos()
                    .Where(x => x.NumEncontro == numeroEncontro)
                    .Where(x => x.PessoaId == idCliente).FirstOrDefault();
        }

        public void Salvar(Encontro model)
        {
            if (model.NumEncontro == 0)
                throw new Exception("Informe o Número do Encontro!");

            if (model.PessoaId == 0)
                throw new Exception("Informe a Pessoa!");

            if (model.Id == 0)
            {
                if (model.TipoExpositor == 2)
                    model.NumeroFicha = _session.ServiceSequencia.ProximaFichaExpositorVisitante();
                if (model.TipoExpositor == 1)
                    model.NumeroFicha = _session.ServiceSequencia.ProximaFichaSocioExpositor();
                _repositorioEncontro.Adicionar(ref model);
            }
            else
                _repositorioEncontro.Alterar(model);
        }
    }
}
