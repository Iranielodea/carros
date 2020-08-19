using Carros.CrosPlataform;
using Carros.Dominio.Interfaces;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmEmail : Form
    {
        private IDalSession _session;

        public frmEmail()
        {
            InitializeComponent();
            _session = SessionFactory.Criar();
        }

        private void frmEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            CarregarEncontro();
            btnEmail.Focus();
        }

        private void CarregarEncontro()
        {
            var CadEncontro = _session.ServiceCadEncontro.ObterNumeroEncontroAtual();
            txtNumEncontro.Text = CadEncontro.NumeroEncontro.ToString();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            ListarEmail();
        }

        private void ListarEmail()
        {
            var tipo = new Comum.EnTipoExpositor();

            if (rbExpSocio.Checked)
                tipo = Comum.EnTipoExpositor.expSocio;
            else if (rbExpVisita.Checked)
                tipo = Comum.EnTipoExpositor.expVisitante;
            else
                tipo = Comum.EnTipoExpositor.expCadSocio;

            var pessoas = _session.ServicePessoa.ListarEmails(Convert.ToInt32(txtNumEncontro.Text), tipo);
            string email = "";
            foreach (var pessoa in pessoas)
            {
                if (!string.IsNullOrEmpty(pessoa))
                    email = email + pessoa + ";\n";
            }
            rtbEmail.Text = email;
        }

        private void frmEmail_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
