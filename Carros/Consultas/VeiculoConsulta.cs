using Carros.Cadastros;
using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class VeiculoConsulta
    {
        private readonly IDalSession _session;

        public VeiculoConsulta(IDalSession session)
        {
            _session = session;
        }

        public Veiculo Pesquisar(string placa, TipoConsulta tipo)
        {
            Veiculo model = new Veiculo();

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmVeiculo(true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _session.ServiceVeiculo.RetornarPorId(Funcoes.IdRetorno);
            }
            else
                model = _session.ServiceVeiculo.ObterPorPlaca(placa);

            if (model != null)
                model.Marca = _session.ServiceMarca.RetornarPorId(model.IdMarca);
            return model;
        }
    }
}
