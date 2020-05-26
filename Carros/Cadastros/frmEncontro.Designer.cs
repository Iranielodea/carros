namespace Carros.Cadastros
{
    partial class frmEncontro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEncontro));
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoExpositor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncontro = new System.Windows.Forms.TextBox();
            this.txtCodPessoa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtFicha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpositor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumEncontro = new System.Windows.Forms.TextBox();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.btnVeiculo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.SuspendLayout();
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumEncontro);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.cbCampos, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtTexto, 0);
            this.groupBox1.Controls.SetChildIndex(this.label8, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtNumEncontro, 0);
            // 
            // txtTexto
            // 
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVeiculo);
            this.groupBox2.Controls.SetChildIndex(this.btnNovo, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnEditar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnExcluir, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnSair, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnFiltro, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnVeiculo, 0);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(498, 19);
            this.btnSair.TabIndex = 5;
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.txtIdPessoa);
            this.tbPrincipal.Controls.Add(this.btnPessoa);
            this.tbPrincipal.Controls.Add(this.txtExpositor);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtFicha);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.txtCodPessoa);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtEncontro);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtData);
            this.tbPrincipal.Controls.Add(this.label3);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(596, 19);
            this.btnPesquisar.Size = new System.Drawing.Size(97, 34);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdPessoa,
            this.Descricao,
            this.Codigo,
            this.Nome,
            this.TipoExpositor});
            this.dgvDados.Location = new System.Drawing.Point(6, 70);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(685, 224);
            this.dgvDados.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 60;
            // 
            // IdPessoa
            // 
            this.IdPessoa.DataPropertyName = "IdPessoa";
            this.IdPessoa.HeaderText = "IdPessoa";
            this.IdPessoa.Name = "IdPessoa";
            this.IdPessoa.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "NumeroFicha";
            this.Descricao.HeaderText = "Nº Ficha";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 60;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 60;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Width = 300;
            // 
            // TipoExpositor
            // 
            this.TipoExpositor.DataPropertyName = "TipoExpositor";
            this.TipoExpositor.HeaderText = "Tipo Expositor";
            this.TipoExpositor.Name = "TipoExpositor";
            this.TipoExpositor.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(31, 36);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(80, 20);
            this.txtData.TabIndex = 0;
            this.txtData.TabStop = false;
            this.txtData.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nº Encontro";
            // 
            // txtEncontro
            // 
            this.txtEncontro.Location = new System.Drawing.Point(138, 36);
            this.txtEncontro.Name = "txtEncontro";
            this.txtEncontro.ReadOnly = true;
            this.txtEncontro.Size = new System.Drawing.Size(100, 20);
            this.txtEncontro.TabIndex = 1;
            this.txtEncontro.TabStop = false;
            // 
            // txtCodPessoa
            // 
            this.txtCodPessoa.Location = new System.Drawing.Point(31, 90);
            this.txtCodPessoa.Name = "txtCodPessoa";
            this.txtCodPessoa.ReadOnly = true;
            this.txtCodPessoa.Size = new System.Drawing.Size(80, 20);
            this.txtCodPessoa.TabIndex = 2;
            this.txtCodPessoa.TabStop = false;
            this.txtCodPessoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPessoa_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pessoa";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(117, 90);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(393, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // txtFicha
            // 
            this.txtFicha.Location = new System.Drawing.Point(31, 138);
            this.txtFicha.Name = "txtFicha";
            this.txtFicha.ReadOnly = true;
            this.txtFicha.Size = new System.Drawing.Size(80, 20);
            this.txtFicha.TabIndex = 4;
            this.txtFicha.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Nº Ficha";
            // 
            // txtExpositor
            // 
            this.txtExpositor.Location = new System.Drawing.Point(120, 138);
            this.txtExpositor.Name = "txtExpositor";
            this.txtExpositor.ReadOnly = true;
            this.txtExpositor.Size = new System.Drawing.Size(183, 20);
            this.txtExpositor.TabIndex = 5;
            this.txtExpositor.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tipo Expositor";
            // 
            // btnPessoa
            // 
            this.btnPessoa.Location = new System.Drawing.Point(516, 90);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(35, 23);
            this.btnPessoa.TabIndex = 10;
            this.btnPessoa.TabStop = false;
            this.btnPessoa.Text = "...";
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nº Encontro";
            // 
            // txtNumEncontro
            // 
            this.txtNumEncontro.Location = new System.Drawing.Point(320, 31);
            this.txtNumEncontro.Name = "txtNumEncontro";
            this.txtNumEncontro.ReadOnly = true;
            this.txtNumEncontro.Size = new System.Drawing.Size(73, 20);
            this.txtNumEncontro.TabIndex = 5;
            this.txtNumEncontro.TabStop = false;
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.Location = new System.Drawing.Point(304, 36);
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(45, 20);
            this.txtIdPessoa.TabIndex = 11;
            this.txtIdPessoa.Visible = false;
            // 
            // btnVeiculo
            // 
            this.btnVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeiculo.ImageKey = "Delivery.png";
            this.btnVeiculo.ImageList = this.imageList1;
            this.btnVeiculo.Location = new System.Drawing.Point(400, 19);
            this.btnVeiculo.Name = "btnVeiculo";
            this.btnVeiculo.Size = new System.Drawing.Size(92, 34);
            this.btnVeiculo.TabIndex = 4;
            this.btnVeiculo.Text = "Veículos";
            this.btnVeiculo.UseVisualStyleBackColor = true;
            this.btnVeiculo.Click += new System.EventHandler(this.btnVeiculo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Hungup.png");
            this.imageList1.Images.SetKeyName(1, "Delivery.png");
            // 
            // frmEncontro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(705, 402);
            this.Name = "frmEncontro";
            this.Text = "Lançamentos do Encontro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEncontro_FormClosed);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnPessoa;
        private System.Windows.Forms.TextBox txtExpositor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFicha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCodPessoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEncontro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumEncontro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.Button btnVeiculo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoExpositor;
    }
}
