using Carros.Comum;
using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmUsuario : Carros.Base.frmConsultaBase
    {
        private Usuario _model;
        private DalSession _session;

        public frmUsuario()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);
            _session = new DalSession();

            Geral.Grade.Config(dgvDados);

            _model = new Usuario();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _session.ServiceUsuario.ListarPorNome(txtTexto.Text, id);
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarConsulta(0);
                dgvDados.Focus();
            }
        }

        private void VincularDados()
        {
            txtCodigo.DataBindings.Clear();
            txtNome.DataBindings.Clear();
            txtSenha.DataBindings.Clear();
            txtConfirmarSenha.Clear();

            txtCodigo.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", _model, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSenha.DataBindings.Add("Text", _model, "Senha", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _session.ServiceUsuario.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            base.Editar();

            VincularDados();
            txtNome.Focus();
        }

        public override void Salvar()
        {
            try
            {
                //_model.RedigitarSenha = txtConfirmarSenha.Text;
                _session.ServiceUsuario.Salvar(_model);
                base.Salvar();

                CarregarConsulta(_model.Id);
                txtTexto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Usuario();
            VincularDados();
            txtNome.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _session.ServiceUsuario.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
                CarregarConsulta(0);
                txtTexto.Focus();
            }
        }

        public override void Filtrar()
        {
            base.Filtrar();
            CarregarConsulta(0);
            txtTexto.Focus();
        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
