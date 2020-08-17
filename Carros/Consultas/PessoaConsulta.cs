using Carros.Cadastros;
using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System.Linq;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class PessoaConsulta
    {
        private readonly IDalSession _session;
        public PessoaConsulta(IDalSession session)
        {
            _session = session;
        }

        public Pessoa Pesquisar(int id, string descricao, TipoConsulta tipo, EnTipoExpositor tipoExpositor)
        {
            Pessoa model = new Pessoa();

            if (tipo == TipoConsulta.Id)
            {
                model = _session.ServicePessoa.RetornarPorId(id);
            }
            if (tipo == TipoConsulta.Descricao)
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    var lista = _session.ServicePessoa.ListarPorNome(descricao);

                    if (lista.Count == 1)
                        model = _session.ServicePessoa.RetornarPorId(lista.Single().Id);
                    else
                    {
                        var frm = new frmVisitante(tipoExpositor, true, descricao);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            model = _session.ServicePessoa.RetornarPorId(Funcoes.IdRetorno);
                    }
                }
            }

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmVisitante(tipoExpositor, true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _session.ServicePessoa.RetornarPorId(Funcoes.IdRetorno);
            }
            return model;
        }
    }
}
