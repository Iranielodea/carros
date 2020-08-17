using Carros.Cadastros;
using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System.Linq;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class ProfissaoConsulta
    {
        private readonly IDalSession _session;

        public ProfissaoConsulta(IDalSession session)
        {
            _session = session;
        }

        public Profissao Pesquisar(int id, string descricao, TipoConsulta tipo)
        {
            Profissao model = new Profissao();

            if (tipo == TipoConsulta.Id)
                model = _session.ServiceProfissao.RetornarPorId(id);

            if (tipo == TipoConsulta.Descricao)
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    var lista = _session.ServiceProfissao.ListarPorNome(descricao);

                    if (lista.Count == 1)
                        model = lista.Single();
                    else
                    {
                        var frm = new frmProfissao(true, descricao);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            model = _session.ServiceProfissao.RetornarPorId(Funcoes.IdRetorno);
                    }
                }
            }

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmProfissao(true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _session.ServiceProfissao.RetornarPorId(Funcoes.IdRetorno);
            }
            return model;
        }
    }
}
