using Carros.CrosPlataform;
using Carros.Dominio.Interfaces;
using Carros.Servico;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmLogin : Form
    {
        private DalSession _session;

        public frmLogin()
        {
            InitializeComponent();
            BootStrapper.ConfigureStructerMap();
            RegisterMappings.Register();
            _session = new DalSession();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                _session.ServiceUsuario.ObterPorUsuario(txtUsuario.Text, txtSenha.Text);
                frmMenu menu = new frmMenu();
                menu.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _session.ServiceTabControle.AtualizarVersao();

            var CadEncontro = _session.ServiceCadEncontro.ObterNumeroEncontroAtual();
            txtEncontro.Text = CadEncontro.Descricao;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
