using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServicePessoa : ServiceBase<Pessoa>, IServicePessoa
    {
        private IRepositoryPessoa _repositorioPessoa;
        private readonly IDalSession _session;

        public ServicePessoa(IRepositoryPessoa repositorioPessoa, IDalSession session) : base(repositorioPessoa)
        {
            _session = session;
            _repositorioPessoa = repositorioPessoa;
        }

        public void Excluir(int id)
        {
            _repositorioPessoa.Deletar(_repositorioPessoa.RetornarPorId(id));
        }

        private IEnumerable<PessoaPesquisa> Filtrar(PessoaFiltro pessoaFiltro, EnTipoExpositor enTipoExpositor, int id = 0)
        {
            IQueryable<PessoaPesquisa> resultado;

            if (enTipoExpositor == EnTipoExpositor.expCadSocio)
                resultado = _repositorioPessoa.ListarCadastroSocios();
            else if (enTipoExpositor == EnTipoExpositor.expSocio)
                resultado = _repositorioPessoa.ListarSociosExpositores();
            else if (enTipoExpositor == EnTipoExpositor.expExpositores)
                resultado = _repositorioPessoa.ListarExpositoresVisitantes();
            else
                resultado = _repositorioPessoa.ListarTodosExpositores();

            if (!string.IsNullOrWhiteSpace(pessoaFiltro.Nome))
                resultado = resultado.Where(x => x.Nome.Contains(pessoaFiltro.Nome));

            if (!string.IsNullOrWhiteSpace(pessoaFiltro.CPF))
            {
                resultado = resultado.Where(x => x.CPF == pessoaFiltro.CPF.SoNumeros());
            }

            if (!string.IsNullOrWhiteSpace(pessoaFiltro.RG))
                resultado = resultado.Where(x => x.RG == pessoaFiltro.RG);

            if (!string.IsNullOrWhiteSpace(pessoaFiltro.Telefone))
                resultado = resultado.Where(x => x.Telefone == pessoaFiltro.Telefone);

            if (id > 0)
                resultado = resultado.Where(x => x.Id == id);

            return resultado.ToList();
        }

        public List<PessoaPesquisa> FiltrarCadastroSocios(PessoaFiltro filtro, int id = 0)
        {
            var resultado = Filtrar(filtro, EnTipoExpositor.expCadSocio, id);
            return resultado.OrderBy(x => x.Nome).ToList();
        }

        public List<PessoaPesquisa> FiltrarExpositores(PessoaFiltro filtro, int id = 0)
        {
            var resultado = Filtrar(filtro, EnTipoExpositor.expExpositores, id);
            //if (id == 0)
            //    resultado = resultado.Where(x => x.CodigoSocio != null);
            return resultado.OrderBy(x => x.Nome).ToList();
        }

        public List<PessoaPesquisa> FiltrarSocios(PessoaFiltro pessoaFiltro, int id = 0)
        {
            var resultado = Filtrar(pessoaFiltro, EnTipoExpositor.expSocio, id);
            return resultado.OrderBy(x => x.Nome).ToList();
        }

        public List<PessoaPesquisa> FiltrarTodos(PessoaFiltro filtro, int id = 0)
        {
            var resultado = Filtrar(filtro, EnTipoExpositor.expTodos, id);
            return resultado.OrderBy(x => x.Nome).ToList();
        }

        public List<PessoaPesquisa> FiltrarVisitantes(PessoaFiltro filtro, int id = 0)
        {
            var resultado = Filtrar(filtro, EnTipoExpositor.expVisitante, id);
            return resultado.OrderBy(x => x.Nome).ToList();
        }

        public List<string> ListarEmails(int numeroEncontro, EnTipoExpositor tipo)
        {
            return _repositorioPessoa.ListarEmails(numeroEncontro, tipo).ToList();
        }

        public List<PessoaPesquisa> ListarPorNome(string nome)
        {
            return _repositorioPessoa.ListarExpositoresVisitantes()
                    .Where(x => x.Nome.Contains(nome)).OrderBy(x => x.Nome).ToList();
        }

        public int ObterNumeroFichar(int idPessoa)
        {
            var resultado = _session.ServiceCadEncontro.RetornarTodos().FirstOrDefault(x => x.EventoAtual == "S");
            if (resultado != null)
            {
                var Encontro = _session.ServiceEncontro.ObterNumeroFicha(idPessoa, resultado.NumeroEncontro);
                if (Encontro != null)
                    return Encontro.NumeroFicha.Value;
                else
                    return 0;
            }
            else
                return 0;

        }

        public Pessoa ObterPorCPF(string cpf, EnTipoExpositor enTipoExpositor)
        {
            var model = _repositorioPessoa.RetornarTodos()
                    .Where(x => x.CPF == cpf.SoNumeros());

            if (enTipoExpositor == EnTipoExpositor.expCadSocio)
                model.Where(x => x.CodigoSocio.HasValue);

            if (enTipoExpositor == EnTipoExpositor.expExpositores)
                model.Where(x => x.CodigoFicha.HasValue);

            if (enTipoExpositor == EnTipoExpositor.expVisitante)
                model.Where(x => x.CodigoVisita.HasValue);

            return model.FirstOrDefault();
        }

        public Pessoa ObterPorSocio(int codigo)
        {
            var model = _repositorioPessoa.RetornarTodos()
                    .FirstOrDefault(x => x.CodigoFicha == codigo);
            return model;
        }

        public Pessoa ObterPorSocioVisitante(int codigo)
        {
            var model = _repositorioPessoa.RetornarTodos()
                    .FirstOrDefault(x => x.CodigoSocio == codigo);
            return model;
        }

        public Pessoa ObterPorVisitante(int codigo)
        {
            var model = _repositorioPessoa.RetornarTodos()
                    .FirstOrDefault(x => x.CodigoVisita == codigo);
            return model;
        }

        public void Salvar(Pessoa model, EnTipoExpositor tipoExpositor)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            if (!Validacao.ValidarCPF(model.CPF))
                throw new Exception("CPF inválido");

            model.CPF = model.CPF.SoNumeros();
            model.CEP = model.CEP.SoNumeros();

            if (model.Id == 0)
            {
                //var sequenciaServico = new ServicoSequencia(); // SequenciaServico();
                if (tipoExpositor == EnTipoExpositor.expCadSocio)
                    model.CodigoSocio = _session.ServiceSequencia.IncrementarProximoNumero("SOCIO", "Cadastro de Sócios");
                if (tipoExpositor == EnTipoExpositor.expSocio)
                    model.CodigoFicha = _session.ServiceSequencia.IncrementarProximoNumero("PESSOA", "Expositor do Clube");
                if (tipoExpositor == EnTipoExpositor.expVisitante)
                    model.CodigoVisita = _session.ServiceSequencia.IncrementarProximoNumero("EXP_VISITA", "Expositor Visitante");
                _repositorioPessoa.Adicionar(ref model);
            }
            else
                _repositorioPessoa.Alterar(model);
        }
    }
}
