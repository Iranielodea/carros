using Carros.Comum;
using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmCidade : Carros.Base.frmConsultaBase
    {
        private Cidade _model;
        private DalSession _session;

        public frmCidade()
        {
            Iniciar();
        }

        public frmCidade( bool Pesquisar = false, string texto = "")
        {
            btnPesquisar.Visible = Pesquisar;
            txtTexto.Text = texto;
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _session = new DalSession();

            Geral.Grade.Config(dgvDados);

            _model = new Cidade();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _session.ServiceCidade.ListarPorNome(txtTexto.Text, id);
            //using (var session = new DalSession())
            //{
            //    dgvDados.DataSource = session.ServiceCidade.ListarPorNome(txtTexto.Text, id);
            //}
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
            txtDescricao.DataBindings.Clear();
            txtCEP.DataBindings.Clear();
            txtUF.DataBindings.Clear();

            txtCodigo.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDescricao.DataBindings.Add("Text", _model, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCEP.DataBindings.Add("Text", _model, "CEP", true, DataSourceUpdateMode.OnPropertyChanged);
            txtUF.DataBindings.Add("Text", _model, "UF", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _session.ServiceCidade.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));

            //using (var session = new DalSession())
            //{
            //    _model = session.ServiceCidade.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            //}

            base.Editar();

            VincularDados();
            txtDescricao.Focus();
        }

        public override void Salvar()
        {
            _session.ServiceCidade.Salvar(_model);

            //using (var session = new DalSession())
            //{
            //    session.ServiceCidade.Salvar(_model);
            //}
            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Cidade();
            VincularDados();
            txtDescricao.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _session.ServiceCidade.Deletar(_session.ServiceCidade.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString())));

                //using (var session = new DalSession())
                //{
                //    session.ServiceCidade.Deletar(session.ServiceCidade.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString())));
                //}
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

        public override void Pesquisar()
        {
            base.Pesquisar();

            if (dgvDados.RowCount > 0)
            {
                Funcoes.IdRetorno = int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString());
                Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (btnPesquisar.Visible)
                Pesquisar();
        }

        private void dgvDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnPesquisar.Visible)
            {
                if (e.KeyCode == Keys.Return)
                    Pesquisar();
            }
        }

        private void frmCidade_Shown(object sender, EventArgs e)
        {
            if (btnPesquisar.Visible && dgvDados.RowCount > 0 && txtTexto.Text != "")
                dgvDados.Focus();
        }

        private void frmCidade_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_unitOfWork.Dispose();
            _session.Dispose();
        }
    }
}
