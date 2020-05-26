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
        public frmLogin()
        {
            InitializeComponent();
            BootStrapper.ConfigureStructerMap();
            RegisterMappings.Register();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (var unit = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                try
                {
                    try
                    {
                        unit.ServicoUsuario.ObterPorUsuario(txtUsuario.Text, txtSenha.Text);
                        frmMenu menu = new frmMenu();
                        menu.Show();
                        this.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtUsuario.Focus();
                }
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
            using (var unit = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                unit.ServicoTabControle.AtualizarVersao();

                var CadEncontro = unit.ServicoCadEncontro.ObterNumeroEncontroAtual();
                txtEncontro.Text = CadEncontro.Descricao;
            }
        }
    }
}
