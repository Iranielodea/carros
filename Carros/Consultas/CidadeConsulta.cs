using Carros.Cadastros;
using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System.Linq;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class CidadeConsulta
    {
        private readonly IDalSession _session;

        public CidadeConsulta(IDalSession session)
        {
            _session = session;
        }
        public Cidade Pesquisar(int id, string descricao, TipoConsulta tipo)
        {
            Cidade model = new Cidade();

            if (tipo == TipoConsulta.Id)
                model = _session.ServiceCidade.RetornarPorId(id);
            if (tipo == TipoConsulta.Descricao)
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    var lista = _session.ServiceCidade.ListarPorNome(descricao);

                    if (lista.Count() == 1)
                        model = lista.Single();
                    else
                    {
                        //var frm = CompositionRoot.ResolveWithArgument<frmCidade>(new Ninject.Parameters.ConstructorArgument("pesquisa", true));
                        var frm = new frmCidade(true, descricao);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            model = _session.ServiceCidade.RetornarPorId(Funcoes.IdRetorno);
                    }
                }
            }

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmCidade(true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _session.ServiceCidade.RetornarPorId(Funcoes.IdRetorno);
            }
            return model;
        }
    }
}
