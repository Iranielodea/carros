using Carros.Comum;
using Carros.Consultas;
using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using System;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Cadastros
{
    public partial class frmEncontro : Carros.Base.frmConsultaBase
    {
        private Encontro _model;
        private int _id;
        private DalSession _session;

        public frmEncontro()
        {
            if (txtTexto.Text == "")
                txtTexto.Text = "ABCDE";
            Iniciar();
        }

        public frmEncontro(bool Pesquisar = false, string texto = "")
        {
            btnPesquisar.Visible = Pesquisar;
            if (texto == "")
                texto = "ABCDE";
            txtTexto.Text = texto;
            Iniciar();

            if (btnPesquisar.Visible && dgvDados.RowCount > 0)
                dgvDados.Focus();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _session = new DalSession();

            Geral.Grade.Config(dgvDados);

            txtNumEncontro.Text = _session.ServiceEncontro.ObterEncontroAtual();
            CarregarConsulta();

            _model = new Encontro();

            if (txtTexto.Text == "ABCDE")
                txtTexto.Text = "";
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _session.ServiceEncontro.ListarPorNome(txtTexto.Text, Funcoes.StrToIntDef(txtNumEncontro.Text, 0), id);
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
            txtData.DataBindings.Clear();
            txtFicha.DataBindings.Clear();
            txtExpositor.Clear();
            txtCodPessoa.Clear();
            txtNome.Clear();
            txtEncontro.Clear();

            txtData.DataBindings.Add("Text", _model, "Data", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFicha.DataBindings.Add("Text", _model, "NumeroFicha", true, DataSourceUpdateMode.OnPropertyChanged);
            txtExpositor.Text = _model.TipoExpositor.ToString();
            txtCodPessoa.Text = _model.Pessoa.Codigo.ToString();
            txtNome.Text = _model.Pessoa.Nome;
            txtEncontro.Text = _model.NumEncontro.ToString();
            _id = _model.Id;

            if (_model.Id == 0)
            {
                txtData.Text = DateTime.Now.Date.ToShortDateString();
                txtEncontro.Text = txtNumEncontro.Text;
                txtCodPessoa.Clear();
                txtFicha.Clear();
            }
            else
            {
                if (_model.Pessoa.CodigoFicha != null)
                    txtCodPessoa.Text = _model.Pessoa.CodigoFicha.ToString();
                if (_model.Pessoa.CodigoVisita != null)
                    txtCodPessoa.Text = _model.Pessoa.CodigoVisita.ToString();
            }

            if (_model.Pessoa.CodigoFicha != null)
                txtExpositor.Text = "1 - Sócio";
            if (_model.Pessoa.CodigoVisita != null)
                txtExpositor.Text = "2 - Visitante";
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _session.ServiceEncontro.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            _model.Pessoa = _session.ServicePessoa.RetornarPorId(_model.PessoaId);
            base.Editar();

            VincularDados();
            btnSalvar.Enabled = false;
            txtNome.Focus();
        }

        public override void Salvar()
        {
            string tipoExpositor = txtExpositor.Text;
            tipoExpositor = tipoExpositor.Substring(0, 1);

            _model.Id = _id;
            _model.PessoaId = Funcoes.StrToIntDef(txtIdPessoa.Text, 0);
            _model.NumeroFicha = Funcoes.StrToIntDef(txtFicha.Text, 0);
            _model.TipoExpositor = Funcoes.StrToIntDef(tipoExpositor, 0);
            _model.NumEncontro = Funcoes.StrToIntDef(txtEncontro.Text, 0);

            _session.ServiceEncontro.Salvar(_model);
            base.Salvar();
            CarregarConsulta(_model.Id);

            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Encontro();
            VincularDados();
            btnSalvar.Enabled = true;
            txtNome.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _session.ServiceEncontro.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
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

        private void PesquisarPessoa(int id, string descricao, TipoConsulta tipo)
        {
            if (id == 0 && tipo == TipoConsulta.Id)
            {
                txtCodPessoa.Clear();
                txtNome.Clear();
                txtIdPessoa.Clear();
                return;
            }

            var pessoa = new PessoaConsulta(_session);
            var model = new Pessoa();

            model = pessoa.Pesquisar(id, descricao, tipo, EnTipoExpositor.expTodos);

            if (model.Id == 0 && tipo == TipoConsulta.Id)
            {
                MessageBox.Show("Registro não Encontrado!");
            }

            if (tipo == TipoConsulta.Tela && model.Id == 0)
                return;

            txtIdPessoa.Text = Funcoes.IntToStr(model.Id);
            txtNome.Text = model.Nome;

            if (model.CodigoVisita != null)
            {
                txtCodPessoa.Text = model.CodigoVisita.ToString();
                txtExpositor.Text = "2 - Visitante";
                //txtFicha.Text = sequencia.ProximaVisitanteMaisUm().ToString();
            }

            if (model.CodigoSocio != null)
            {
                txtCodPessoa.Clear();
                txtNome.Clear();
                txtIdPessoa.Clear();
                MessageBox.Show("Sócios não podem participar!");
                return;
            }

            if (model.CodigoFicha != null)
            {
                txtCodPessoa.Text = model.CodigoFicha.ToString();
                txtExpositor.Text = "1 - Sócio";
                //txtFicha.Text = sequencia.ProximoSocioMaisUm().ToString();
            }
            txtNome.Focus();

            txtCodPessoa.Modified = false;
            txtNome.Modified = false;
        }

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            PesquisarPessoa(0, "", TipoConsulta.Tela);
            if (btnSalvar.Enabled)
                btnSalvar.Focus();
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Modified)
            {
                if (txtNome.Text.Trim() == "")
                    txtCodPessoa.Clear();
                else
                    PesquisarPessoa(Funcoes.StrToIntDef(txtCodPessoa.Text, 0), txtNome.Text, TipoConsulta.Descricao);
            }
        }

        private void txtCodPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                PesquisarPessoa(Funcoes.StrToIntDef(txtCodPessoa.Text, 0), txtNome.Text, TipoConsulta.Tela);
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            if (dgvDados.RowCount > 0)
            {
                var Encontro = new Encontro();
                Encontro = _session.ServiceEncontro.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
                if (Encontro != null)
                {
                    frmPessoaVeiculo f = new frmPessoaVeiculo(true, Encontro.PessoaId);
                    f.ShowDialog();
                }
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                PesquisarPessoa(Funcoes.StrToIntDef(txtCodPessoa.Text, 0), txtNome.Text, TipoConsulta.Tela);
        }

        private void frmEncontro_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
