namespace Carros.Cadastros
{
    partial class frmVisitante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitante));
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIdCidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescCidade = new System.Windows.Forms.TextBox();
            this.btnMarca = new System.Windows.Forms.Button();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.txtFicha = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tpCompl = new System.Windows.Forms.TabPage();
            this.txtFatorRH = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTipoSangue = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtConjuge = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnProfissao = new System.Windows.Forms.Button();
            this.txtDescProfissao = new System.Windows.Forms.TextBox();
            this.txtIdProfissao = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMae = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPai = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnContato = new System.Windows.Forms.Button();
            this.btnVeiculo = new System.Windows.Forms.Button();
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.rbCadSocio = new System.Windows.Forms.RadioButton();
            this.rbExpSocio = new System.Windows.Forms.RadioButton();
            this.rbExpVisitante = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tpPesquisa.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tbPrincipal.SuspendLayout();
            this.tpFiltro.SuspendLayout();
            this.tpEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.tpCompl.SuspendLayout();
            this.gbTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(718, 438);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(710, 412);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpCompl);
            this.tabControl2.Size = new System.Drawing.Size(701, 345);
            this.tabControl2.Controls.SetChildIndex(this.tpCompl, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tabControl3
            // 
            this.tabControl3.Size = new System.Drawing.Size(687, 336);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(704, 57);
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(236, 31);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Location = new System.Drawing.Point(9, 30);
            this.cbCampos.Visible = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVeiculo);
            this.groupBox2.Controls.Add(this.btnContato);
            this.groupBox2.Location = new System.Drawing.Point(2, 347);
            this.groupBox2.Size = new System.Drawing.Size(705, 59);
            this.groupBox2.Controls.SetChildIndex(this.btnNovo, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnEditar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnExcluir, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnSair, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnFiltro, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnContato, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnVeiculo, 0);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(576, 19);
            this.btnFiltro.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(498, 19);
            this.btnSair.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(3, 354);
            this.groupBox3.Size = new System.Drawing.Size(701, 55);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(3, 338);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.gbTipo);
            this.tbPrincipal.Controls.Add(this.txtId);
            this.tbPrincipal.Controls.Add(this.label16);
            this.tbPrincipal.Controls.Add(this.txtFicha);
            this.tbPrincipal.Controls.Add(this.txtObs);
            this.tbPrincipal.Controls.Add(this.label15);
            this.tbPrincipal.Controls.Add(this.txtTelefone);
            this.tbPrincipal.Controls.Add(this.label14);
            this.tbPrincipal.Controls.Add(this.txtDataCadastro);
            this.tbPrincipal.Controls.Add(this.label13);
            this.tbPrincipal.Controls.Add(this.txtCPF);
            this.tbPrincipal.Controls.Add(this.label12);
            this.tbPrincipal.Controls.Add(this.txtUF);
            this.tbPrincipal.Controls.Add(this.label11);
            this.tbPrincipal.Controls.Add(this.txtCEP);
            this.tbPrincipal.Controls.Add(this.label10);
            this.tbPrincipal.Controls.Add(this.txtBairro);
            this.tbPrincipal.Controls.Add(this.label9);
            this.tbPrincipal.Controls.Add(this.txtEndereco);
            this.tbPrincipal.Controls.Add(this.label8);
            this.tbPrincipal.Controls.Add(this.txtDataNasc);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.txtEmail);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtRG);
            this.tbPrincipal.Controls.Add(this.lblModelo);
            this.tbPrincipal.Controls.Add(this.btnMarca);
            this.tbPrincipal.Controls.Add(this.txtDescCidade);
            this.tbPrincipal.Controls.Add(this.txtIdCidade);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Size = new System.Drawing.Size(693, 319);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(679, 310);
            // 
            // tpFiltro
            // 
            this.tpFiltro.Size = new System.Drawing.Size(710, 412);
            // 
            // tpEditar
            // 
            this.tpEditar.Size = new System.Drawing.Size(710, 412);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(236, 15);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Visible = true;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(599, 19);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Descricao,
            this.Marca,
            this.Telefone});
            this.dgvDados.Location = new System.Drawing.Point(3, 69);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(704, 267);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDados_KeyDown);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            this.Codigo.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Nome";
            this.Descricao.HeaderText = "Nome";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 350;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "CPF";
            this.Marca.HeaderText = "CPF";
            this.Marca.Name = "Marca";
            this.Marca.Width = 150;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Código";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nome";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(17, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(100, 33);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(417, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtIdCidade
            // 
            this.txtIdCidade.Location = new System.Drawing.Point(17, 115);
            this.txtIdCidade.MaxLength = 5;
            this.txtIdCidade.Name = "txtIdCidade";
            this.txtIdCidade.Size = new System.Drawing.Size(78, 20);
            this.txtIdCidade.TabIndex = 5;
            this.txtIdCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCidade_KeyDown);
            this.txtIdCidade.Leave += new System.EventHandler(this.txtIdCidade_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cidade";
            // 
            // txtDescCidade
            // 
            this.txtDescCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCidade.Location = new System.Drawing.Point(100, 115);
            this.txtDescCidade.Name = "txtDescCidade";
            this.txtDescCidade.Size = new System.Drawing.Size(349, 20);
            this.txtDescCidade.TabIndex = 6;
            this.txtDescCidade.Leave += new System.EventHandler(this.txtDescCidade_Leave);
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(455, 113);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(40, 23);
            this.btnMarca.TabIndex = 5;
            this.btnMarca.TabStop = false;
            this.btnMarca.Text = "...";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(158, 157);
            this.txtRG.MaxLength = 20;
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(133, 20);
            this.txtRG.TabIndex = 10;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(155, 141);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(23, 13);
            this.lblModelo.TabIndex = 7;
            this.lblModelo.Text = "RG";
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(17, 196);
            this.txtEmail.MaxLength = 80;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(518, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data Nascimento";
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.Location = new System.Drawing.Point(523, 33);
            this.txtDataNasc.Mask = "00/00/0000";
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(86, 20);
            this.txtDataNasc.TabIndex = 2;
            this.txtDataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // txtEndereco
            // 
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Location = new System.Drawing.Point(17, 74);
            this.txtEndereco.MaxLength = 50;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(433, 20);
            this.txtEndereco.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Endereço";
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Location = new System.Drawing.Point(455, 74);
            this.txtBairro.MaxLength = 50;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(218, 20);
            this.txtBairro.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(455, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Bairro";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(509, 115);
            this.txtCEP.Mask = "00000-999";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(83, 20);
            this.txtCEP.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(506, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "CEP";
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(598, 116);
            this.txtUF.MaxLength = 20;
            this.txtUF.Name = "txtUF";
            this.txtUF.ReadOnly = true;
            this.txtUF.Size = new System.Drawing.Size(75, 20);
            this.txtUF.TabIndex = 8;
            this.txtUF.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(595, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "UF";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(17, 157);
            this.txtCPF.Mask = "999.999.999-99";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(135, 20);
            this.txtCPF.TabIndex = 9;
            this.txtCPF.Leave += new System.EventHandler(this.txtCPF_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "CPF";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(297, 157);
            this.txtDataCadastro.Mask = "00/00/0000";
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(100, 20);
            this.txtDataCadastro.TabIndex = 11;
            this.txtDataCadastro.TabStop = false;
            this.txtDataCadastro.ValidatingType = typeof(System.DateTime);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(294, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Data Cadastro";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(540, 196);
            this.txtTelefone.MaxLength = 20;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(133, 20);
            this.txtTelefone.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(537, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Telefone";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 219);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Obsevação";
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObs.Location = new System.Drawing.Point(17, 235);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(517, 75);
            this.txtObs.TabIndex = 14;
            // 
            // txtFicha
            // 
            this.txtFicha.Location = new System.Drawing.Point(615, 33);
            this.txtFicha.Name = "txtFicha";
            this.txtFicha.Size = new System.Drawing.Size(58, 20);
            this.txtFicha.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(615, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Ficha";
            // 
            // tpCompl
            // 
            this.tpCompl.BackColor = System.Drawing.Color.Silver;
            this.tpCompl.Controls.Add(this.txtFatorRH);
            this.tpCompl.Controls.Add(this.label23);
            this.tpCompl.Controls.Add(this.txtTipoSangue);
            this.tpCompl.Controls.Add(this.label22);
            this.tpCompl.Controls.Add(this.txtConjuge);
            this.tpCompl.Controls.Add(this.label21);
            this.tpCompl.Controls.Add(this.btnProfissao);
            this.tpCompl.Controls.Add(this.txtDescProfissao);
            this.tpCompl.Controls.Add(this.txtIdProfissao);
            this.tpCompl.Controls.Add(this.label20);
            this.tpCompl.Controls.Add(this.txtEmpresa);
            this.tpCompl.Controls.Add(this.label19);
            this.tpCompl.Controls.Add(this.txtMae);
            this.tpCompl.Controls.Add(this.label18);
            this.tpCompl.Controls.Add(this.txtPai);
            this.tpCompl.Controls.Add(this.label17);
            this.tpCompl.Location = new System.Drawing.Point(4, 22);
            this.tpCompl.Name = "tpCompl";
            this.tpCompl.Padding = new System.Windows.Forms.Padding(3);
            this.tpCompl.Size = new System.Drawing.Size(693, 319);
            this.tpCompl.TabIndex = 1;
            this.tpCompl.Text = "Complemento";
            // 
            // txtFatorRH
            // 
            this.txtFatorRH.Location = new System.Drawing.Point(478, 68);
            this.txtFatorRH.MaxLength = 10;
            this.txtFatorRH.Name = "txtFatorRH";
            this.txtFatorRH.Size = new System.Drawing.Size(175, 20);
            this.txtFatorRH.TabIndex = 7;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(478, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "Fator RH";
            // 
            // txtTipoSangue
            // 
            this.txtTipoSangue.Location = new System.Drawing.Point(478, 25);
            this.txtTipoSangue.MaxLength = 10;
            this.txtTipoSangue.Name = "txtTipoSangue";
            this.txtTipoSangue.Size = new System.Drawing.Size(175, 20);
            this.txtTipoSangue.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(478, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "Tipo Sanguíneo";
            // 
            // txtConjuge
            // 
            this.txtConjuge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConjuge.Location = new System.Drawing.Point(17, 201);
            this.txtConjuge.MaxLength = 50;
            this.txtConjuge.Name = "txtConjuge";
            this.txtConjuge.Size = new System.Drawing.Size(433, 20);
            this.txtConjuge.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 185);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 25;
            this.label21.Text = "Cônjuge";
            // 
            // btnProfissao
            // 
            this.btnProfissao.Location = new System.Drawing.Point(454, 155);
            this.btnProfissao.Name = "btnProfissao";
            this.btnProfissao.Size = new System.Drawing.Size(40, 23);
            this.btnProfissao.TabIndex = 21;
            this.btnProfissao.TabStop = false;
            this.btnProfissao.Text = "...";
            this.btnProfissao.UseVisualStyleBackColor = true;
            this.btnProfissao.Click += new System.EventHandler(this.btnProfissao_Click);
            // 
            // txtDescProfissao
            // 
            this.txtDescProfissao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescProfissao.Location = new System.Drawing.Point(99, 157);
            this.txtDescProfissao.MaxLength = 50;
            this.txtDescProfissao.Name = "txtDescProfissao";
            this.txtDescProfissao.Size = new System.Drawing.Size(349, 20);
            this.txtDescProfissao.TabIndex = 4;
            this.txtDescProfissao.Leave += new System.EventHandler(this.txtDescProfissao_Leave);
            // 
            // txtIdProfissao
            // 
            this.txtIdProfissao.Location = new System.Drawing.Point(16, 157);
            this.txtIdProfissao.MaxLength = 5;
            this.txtIdProfissao.Name = "txtIdProfissao";
            this.txtIdProfissao.Size = new System.Drawing.Size(78, 20);
            this.txtIdProfissao.TabIndex = 3;
            this.txtIdProfissao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdProfissao_KeyDown_1);
            this.txtIdProfissao.Leave += new System.EventHandler(this.txtIdProfissao_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 141);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Profissão";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpresa.Location = new System.Drawing.Point(17, 112);
            this.txtEmpresa.MaxLength = 50;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(433, 20);
            this.txtEmpresa.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Empresa";
            // 
            // txtMae
            // 
            this.txtMae.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMae.Location = new System.Drawing.Point(17, 68);
            this.txtMae.MaxLength = 50;
            this.txtMae.Name = "txtMae";
            this.txtMae.Size = new System.Drawing.Size(433, 20);
            this.txtMae.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Nome da Mãe";
            // 
            // txtPai
            // 
            this.txtPai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPai.Location = new System.Drawing.Point(17, 25);
            this.txtPai.MaxLength = 50;
            this.txtPai.Name = "txtPai";
            this.txtPai.Size = new System.Drawing.Size(433, 20);
            this.txtPai.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Nome do Pai";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(197, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(32, 20);
            this.txtId.TabIndex = 29;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Hungup.png");
            this.imageList1.Images.SetKeyName(1, "Delivery.png");
            // 
            // btnContato
            // 
            this.btnContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContato.ImageIndex = 0;
            this.btnContato.ImageList = this.imageList1;
            this.btnContato.Location = new System.Drawing.Point(302, 19);
            this.btnContato.Name = "btnContato";
            this.btnContato.Size = new System.Drawing.Size(92, 34);
            this.btnContato.TabIndex = 3;
            this.btnContato.Text = "Contatos";
            this.btnContato.UseVisualStyleBackColor = true;
            this.btnContato.Click += new System.EventHandler(this.btnContato_Click);
            // 
            // btnVeiculo
            // 
            this.btnVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeiculo.ImageIndex = 1;
            this.btnVeiculo.ImageList = this.imageList1;
            this.btnVeiculo.Location = new System.Drawing.Point(400, 19);
            this.btnVeiculo.Name = "btnVeiculo";
            this.btnVeiculo.Size = new System.Drawing.Size(92, 34);
            this.btnVeiculo.TabIndex = 4;
            this.btnVeiculo.Text = "Veículos";
            this.btnVeiculo.UseVisualStyleBackColor = true;
            this.btnVeiculo.Click += new System.EventHandler(this.btnVeiculo_Click);
            // 
            // gbTipo
            // 
            this.gbTipo.Controls.Add(this.rbCadSocio);
            this.gbTipo.Controls.Add(this.rbExpSocio);
            this.gbTipo.Controls.Add(this.rbExpVisitante);
            this.gbTipo.Location = new System.Drawing.Point(540, 222);
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.Size = new System.Drawing.Size(133, 88);
            this.gbTipo.TabIndex = 30;
            this.gbTipo.TabStop = false;
            // 
            // rbCadSocio
            // 
            this.rbCadSocio.AutoSize = true;
            this.rbCadSocio.Location = new System.Drawing.Point(9, 65);
            this.rbCadSocio.Name = "rbCadSocio";
            this.rbCadSocio.Size = new System.Drawing.Size(97, 17);
            this.rbCadSocio.TabIndex = 2;
            this.rbCadSocio.TabStop = true;
            this.rbCadSocio.Text = "Cadastro Sócio";
            this.rbCadSocio.UseVisualStyleBackColor = true;
            // 
            // rbExpSocio
            // 
            this.rbExpSocio.AutoSize = true;
            this.rbExpSocio.Location = new System.Drawing.Point(9, 42);
            this.rbExpSocio.Name = "rbExpSocio";
            this.rbExpSocio.Size = new System.Drawing.Size(98, 17);
            this.rbExpSocio.TabIndex = 1;
            this.rbExpSocio.Text = "Expositor Sócio";
            this.rbExpSocio.UseVisualStyleBackColor = true;
            // 
            // rbExpVisitante
            // 
            this.rbExpVisitante.AutoSize = true;
            this.rbExpVisitante.Checked = true;
            this.rbExpVisitante.Location = new System.Drawing.Point(9, 19);
            this.rbExpVisitante.Name = "rbExpVisitante";
            this.rbExpVisitante.Size = new System.Drawing.Size(111, 17);
            this.rbExpVisitante.TabIndex = 0;
            this.rbExpVisitante.TabStop = true;
            this.rbExpVisitante.Text = "Expositor Visitante";
            this.rbExpVisitante.UseVisualStyleBackColor = true;
            // 
            // frmVisitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Name = "frmVisitante";
            this.Text = "Visitante";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVisitante_FormClosed);
            this.Shown += new System.EventHandler(this.frmVisitante_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tpPesquisa.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tbPrincipal.ResumeLayout(false);
            this.tbPrincipal.PerformLayout();
            this.tpFiltro.ResumeLayout(false);
            this.tpEditar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.tpCompl.ResumeLayout(false);
            this.tpCompl.PerformLayout();
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.TextBox txtDescCidade;
        private System.Windows.Forms.TextBox txtIdCidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtDataNasc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtCEP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtDataCadastro;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFicha;
        private System.Windows.Forms.TabPage tpCompl;
        private System.Windows.Forms.TextBox txtFatorRH;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTipoSangue;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtConjuge;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnProfissao;
        private System.Windows.Forms.TextBox txtDescProfissao;
        private System.Windows.Forms.TextBox txtIdProfissao;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMae;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPai;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnContato;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnVeiculo;
        private System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.RadioButton rbCadSocio;
        private System.Windows.Forms.RadioButton rbExpSocio;
        private System.Windows.Forms.RadioButton rbExpVisitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
    }
}
