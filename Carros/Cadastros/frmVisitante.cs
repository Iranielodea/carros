using Carros.Comum;
using Carros.Consultas;
using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using System;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Cadastros
{
    public partial class frmVisitante : Carros.Base.frmConsultaBase
    {
        private Pessoa _model;
        private EnTipoExpositor _tipoExpositor;
        private DalSession _session;

        public frmVisitante()
        {
            InitializeComponent();

            Iniciar("");
        }

        public frmVisitante(EnTipoExpositor tipoExpositor, bool Pesquisar = false, string texto = "")
        {
            InitializeComponent();

            btnPesquisar.Visible = Pesquisar;
            txtTexto.Text = texto;

            switch (tipoExpositor)
            {
                case EnTipoExpositor.expSocio:
                    _tipoExpositor = EnTipoExpositor.expSocio;
                    this.Text = "Cadastro de Sócios Expositores";
                    rbExpSocio.Checked = true;
                    break;
                case EnTipoExpositor.expVisitante:
                    _tipoExpositor = EnTipoExpositor.expVisitante;
                    this.Text = "Cadastro de Expositores Visitantes";
                    rbExpVisitante.Checked = true;
                    break;
                case EnTipoExpositor.expCadSocio:
                    _tipoExpositor = EnTipoExpositor.expCadSocio;
                    this.Text = "Cadastro de Sócios";
                    rbCadSocio.Checked = true;
                    break;
                case EnTipoExpositor.expTodos:
                    _tipoExpositor = EnTipoExpositor.expTodos;
                    this.Text = "Cadastro de Pessoas";
                    break;
                case EnTipoExpositor.expExpositores:
                    _tipoExpositor = EnTipoExpositor.expExpositores;
                    this.Text = "Cadastro de Pessoas";
                    break;
                default:
                    break;
            }

            Iniciar(texto);

            if (btnPesquisar.Visible && dgvDados.RowCount > 0)
                dgvDados.Focus();

        }

        private void Iniciar(string texto)
        {
            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _session = new DalSession();

            Geral.Grade.Config(dgvDados);

            _model = new Pessoa();
            PopularCampos();
            if (!string.IsNullOrWhiteSpace(texto))
                CarregarConsulta();
            txtId.Visible = false;
        }

        private void PopularCampos()
        {
            cbCampos.Items.Add("Nome");
            cbCampos.Items.Add("CPF");
            cbCampos.Items.Add("RG");
            cbCampos.Items.Add("Telefone");
            cbCampos.SelectedIndex = 0;
        }

        private void CarregarConsulta(int id = 0)
        {
            var filtro = new PessoaFiltro();

            if (cbCampos.SelectedIndex == 0)
                filtro.Nome = txtTexto.Text;

            if (cbCampos.SelectedIndex == 1)
                filtro.CPF = txtTexto.Text;

            if (cbCampos.SelectedIndex == 2)
                filtro.RG = txtTexto.Text;

            //if (cbCampos.SelectedIndex == 3)
            //    filtro.NomeCidade = txtTexto.Text;

            //if (cbCampos.SelectedIndex == 4)
            //    filtro.UF = txtTexto.Text;

            if (cbCampos.SelectedIndex == 3)
                filtro.Telefone = txtTexto.Text;

            if (_tipoExpositor == EnTipoExpositor.expCadSocio)
                dgvDados.DataSource = _session.ServicePessoa.FiltrarCadastroSocios(filtro, id);
            else if (_tipoExpositor == EnTipoExpositor.expSocio)
                dgvDados.DataSource = _session.ServicePessoa.FiltrarSocios(filtro, id);
            else if (_tipoExpositor == EnTipoExpositor.expVisitante)
                dgvDados.DataSource = _session.ServicePessoa.FiltrarVisitantes(filtro, id);
            else if (_tipoExpositor == EnTipoExpositor.expTodos)
                dgvDados.DataSource = _session.ServicePessoa.FiltrarTodos(filtro, id);
            else if (_tipoExpositor == EnTipoExpositor.expExpositores)
                dgvDados.DataSource = _session.ServicePessoa.FiltrarExpositores(filtro, id);
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
            txtId.DataBindings.Clear();
            txtCodigo.DataBindings.Clear();
            txtNome.DataBindings.Clear();
            txtDataNasc.DataBindings.Clear();
            txtEndereco.DataBindings.Clear();
            txtBairro.DataBindings.Clear();
            txtCEP.DataBindings.Clear();
            txtCPF.DataBindings.Clear();
            txtRG.DataBindings.Clear();
            txtDataCadastro.DataBindings.Clear();
            txtTelefone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtObs.DataBindings.Clear();
            txtPai.DataBindings.Clear();
            txtMae.DataBindings.Clear();
            txtEmpresa.DataBindings.Clear();
            txtConjuge.DataBindings.Clear();
            txtTipoSangue.DataBindings.Clear();
            txtFatorRH.DataBindings.Clear();

            txtIdCidade.Clear();
            txtDescCidade.Clear();
            txtUF.Clear();

            txtIdProfissao.Clear();
            txtDescProfissao.Clear();
            txtFicha.Clear();

            txtId.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtCodigo.DataBindings.Add("Text", _model, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", _model, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataNasc.DataBindings.Add("Text", _model, "DataNascimento", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEndereco.DataBindings.Add("Text", _model, "Endereco", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBairro.DataBindings.Add("Text", _model, "Bairro", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCEP.DataBindings.Add("Text", _model, "CEP", true, DataSourceUpdateMode.OnPropertyChanged);
            txtRG.DataBindings.Add("Text", _model, "RG", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataCadastro.DataBindings.Add("Text", _model, "DataCadastro", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtCPF.DataBindings.Add("Text", _model, "CPF", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTelefone.DataBindings.Add("Text", _model, "Telefone", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", _model, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            txtObs.DataBindings.Add("Text", _model, "Observacao", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPai.DataBindings.Add("Text", _model, "NomePai", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMae.DataBindings.Add("Text", _model, "NomeMae", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmpresa.DataBindings.Add("Text", _model, "NomeEmpresa", true, DataSourceUpdateMode.OnPropertyChanged);
            txtConjuge.DataBindings.Add("Text", _model, "NomeConjuge", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTipoSangue.DataBindings.Add("Text", _model, "TipoSangue", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFatorRH.DataBindings.Add("Text", _model, "FatorRH", true, DataSourceUpdateMode.OnPropertyChanged);

            if (_model.CidadeId != null)
                txtIdCidade.Text = Funcoes.IntToStr(_model.CidadeId);
            txtDescCidade.Text = _model.Cidade.Nome;
            txtUF.Text = _model.Cidade.UF;

            if (_model.Id > 0)
            {
                if (_model.CodigoFicha != null)
                    txtCodigo.Text = _model.CodigoFicha.ToString();
                if (_model.CodigoSocio != null)
                    txtCodigo.Text = _model.CodigoSocio.ToString();
                if (_model.CodigoVisita != null)
                    txtCodigo.Text = _model.CodigoVisita.ToString();
            }

            if (_model.ProfissaoId != null)
            {
                txtIdProfissao.Text = _model.ProfissaoId.ToString();
                txtDescProfissao.Text = _model.Profissao.Descricao;
            }

            if (_model.Id == 0)
                txtDataCadastro.Text = DateTime.Now.Date.ToShortDateString();

            if (_model.CodigoVisita != null)
                rbExpVisitante.Checked = true;
            if (_model.CodigoSocio != null)
                rbCadSocio.Checked = true;
            if (_model.CodigoFicha != null)
                rbExpSocio.Checked = true;

            BuscarNumeroFicha(_model.Id);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            tabControl2.SelectedIndex = 0;
            _model = _session.ServicePessoa.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            if (_model.CidadeId != null)
                _model.Cidade = _session.ServiceCidade.RetornarPorId(_model.CidadeId.Value);

            if (_model.ProfissaoId != null)
                _model.Profissao = _session.ServiceProfissao.RetornarPorId(_model.ProfissaoId.Value);
            base.Editar();

            txtCPF.Text = _model.CPF.ToString();
            VincularDados();
            gbTipo.Enabled = false;
            txtNome.Focus();
        }

        public override void Salvar()
        {
            try
            {
                int? idProfissao = Funcoes.StrToIntNull(txtIdProfissao.Text);
                _model.ProfissaoId = idProfissao;

                int? idCidade = Funcoes.StrToIntNull(txtIdCidade.Text);
                _model.CidadeId = idCidade;
                _model.Codigo = Convert.ToInt32(txtCodigo.Text);
                _model.CPF = txtCPF.Text;

                if (rbCadSocio.Checked)
                    _tipoExpositor = EnTipoExpositor.expCadSocio;
                else if (rbExpSocio.Checked)
                    _tipoExpositor = EnTipoExpositor.expSocio;
                else if (rbExpVisitante.Checked)
                    _tipoExpositor = EnTipoExpositor.expVisitante;

                _session.ServicePessoa.Salvar(_model, _tipoExpositor);
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
            tabControl2.SelectedIndex = 0;
            base.Novo();
            //if (_model == null)
                _model = new Pessoa();
            txtCodigo.Text = "0";
            gbTipo.Enabled = true;
            txtCPF.Clear();
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
                _session.ServicePessoa.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
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

        private void btnMarca_Click(object sender, EventArgs e)
        {
            PesquisarCidades(Funcoes.StrToIntDef(txtIdCidade.Text, 0), txtDescCidade.Text, TipoConsulta.Tela);
        }

        private void PesquisarCidades(int id, string descricao, TipoConsulta tipo)
        {
            if (id == 0 && tipo == TipoConsulta.Id)
            {
                txtIdCidade.Clear();
                txtDescCidade.Clear();
                txtCEP.Clear();
                txtUF.Clear();
                return;
            }

            var cidade = new CidadeConsulta(_session);
            var model = cidade.Pesquisar(id, descricao, tipo);

            if (model.Id == 0 && tipo == TipoConsulta.Id)
            {
                MessageBox.Show("Registro não Encontrado!");
            }

            if (tipo == TipoConsulta.Tela && model.Id == 0)
                return;

            txtIdCidade.Text = Funcoes.IntToStr(model.Id);
            txtDescCidade.Text = model.Nome;
            txtCEP.Text = model.CEP;
            txtUF.Text = model.UF;
            txtIdCidade.Modified = false;
            txtDescCidade.Modified = false;
            txtDescCidade.Focus();
        }

        private void PesquisarProfissao(int id, string descricao, TipoConsulta tipo)
        {
            if (id == 0 && tipo == TipoConsulta.Id)
            {
                txtIdProfissao.Clear();
                txtDescProfissao.Clear();
                return;
            }

            var profissao = new ProfissaoConsulta(_session);
            var model = profissao.Pesquisar(id, descricao, tipo);

            if (model.Id == 0 && tipo == TipoConsulta.Id)
            {
                MessageBox.Show("Registro não Encontrado!");
            }

            if (tipo == TipoConsulta.Tela && model.Id == 0)
                return;

            txtIdProfissao.Text = Funcoes.IntToStr(model.Id);
            txtDescProfissao.Text = model.Descricao;
            txtIdProfissao.Modified = false;
            txtDescProfissao.Modified = false;
            txtDescProfissao.Focus();
        }

        private void btnProfissao_Click(object sender, EventArgs e)
        {
            PesquisarProfissao(Funcoes.StrToIntDef(txtIdProfissao.Text, 0), txtDescProfissao.Text, TipoConsulta.Tela);
        }

        private void txtIdProfissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                PesquisarProfissao(Funcoes.StrToIntDef(txtIdProfissao.Text, 0), txtDescProfissao.Text, TipoConsulta.Tela);
        }

        private void txtIdProfissao_Leave(object sender, EventArgs e)
        {
            if (txtIdProfissao.Modified)
                PesquisarProfissao(Funcoes.StrToIntDef(txtIdProfissao.Text, 0), txtDescProfissao.Text, TipoConsulta.Id);
        }

        private void txtDescProfissao_Leave(object sender, EventArgs e)
        {
            if (txtDescProfissao.Modified)
            {
                if (txtDescProfissao.Text.Trim() == "")
                    txtIdProfissao.Clear();
                else
                    PesquisarProfissao(Funcoes.StrToIntDef(txtIdProfissao.Text, 0), txtDescProfissao.Text, TipoConsulta.Descricao);
            }
        }

        private void txtDescCidade_Leave(object sender, EventArgs e)
        {
            if (txtDescCidade.Modified)
            {
                if (txtDescCidade.Text.Trim() == "")
                    txtIdCidade.Clear();
                else
                    PesquisarCidades(Funcoes.StrToIntDef(txtIdCidade.Text, 0), txtDescCidade.Text, TipoConsulta.Descricao);
            }
        }

        private void txtIdCidade_Leave(object sender, EventArgs e)
        {
            if (txtIdCidade.Modified)
                PesquisarCidades(Funcoes.StrToIntDef(txtIdCidade.Text, 0), txtDescCidade.Text, TipoConsulta.Id);
        }

        private void txtIdCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                PesquisarCidades(Funcoes.StrToIntDef(txtIdCidade.Text, 0), txtDescCidade.Text, TipoConsulta.Tela);
        }

        private void txtIdProfissao_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                PesquisarProfissao(Funcoes.StrToIntDef(txtIdProfissao.Text, 0), txtDescProfissao.Text, TipoConsulta.Tela);
        }

        private void btnContato_Click(object sender, EventArgs e)
        {
            if (dgvDados.RowCount > 0)
            {
                var cliente = new Pessoa();
                cliente = _session.ServicePessoa.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
                frmContato f = new frmContato(true, cliente.Id);
                f.ShowDialog();
            }
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            if (dgvDados.RowCount > 0)
            {
                var cliente = new Pessoa();
                cliente = _session.ServicePessoa.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
                frmPessoaVeiculo f = new frmPessoaVeiculo(true, cliente.Id);
                f.ShowDialog();
            }
        }

        private void BuscarNumeroFicha(int idPessoa)
        {
            txtFicha.Text = _session.ServicePessoa.ObterNumeroFichar(idPessoa).ToString();
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
            if (e.KeyCode == Keys.Return)
            {
                if (btnPesquisar.Visible)
                    Pesquisar();
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "0")
            {
                _model = _session.ServicePessoa.ObterPorCPF(txtCPF.Text, _tipoExpositor);
                if (_model != null)
                {
                    VincularDados();
                    gbTipo.Enabled = false;
                }
            }
        }

        private void frmVisitante_Shown(object sender, EventArgs e)
        {
            if (btnPesquisar.Visible && dgvDados.RowCount > 0)
                dgvDados.Focus();
        }

        private void frmVisitante_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
