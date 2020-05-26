namespace Carros.Cadastros
{
    partial class frmPessoaVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPessoaVeiculo));
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtIdMarca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNomePessoa = new System.Windows.Forms.TextBox();
            this.txtDescMarca = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVeiculo = new System.Windows.Forms.Button();
            this.txtIdVeiculo = new System.Windows.Forms.TextBox();
            this.btnCertificado = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkImprimir = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Controls.Add(this.chkImprimir);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.cbCampos, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtTexto, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkImprimir, 0);
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(154, 29);
            this.txtTexto.Visible = false;
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCertificado);
            this.groupBox2.Controls.SetChildIndex(this.btnNovo, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnEditar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnExcluir, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnSair, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnFiltro, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnCertificado, 0);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(498, 19);
            this.btnFiltro.Size = new System.Drawing.Size(81, 34);
            this.btnFiltro.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(302, 19);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.txtIdVeiculo);
            this.tbPrincipal.Controls.Add(this.btnVeiculo);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtAno);
            this.tbPrincipal.Controls.Add(this.txtModelo);
            this.tbPrincipal.Controls.Add(this.txtDescMarca);
            this.tbPrincipal.Controls.Add(this.txtNomePessoa);
            this.tbPrincipal.Controls.Add(this.txtId);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.txtIdMarca);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtPlaca);
            this.tbPrincipal.Controls.Add(this.txtIdPessoa);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.label3);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(151, 13);
            this.label2.Visible = false;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Telefone,
            this.Marca,
            this.Modelo,
            this.Ano});
            this.dgvDados.Location = new System.Drawing.Point(3, 69);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(685, 224);
            this.dgvDados.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Placa";
            this.Telefone.HeaderText = "Placa";
            this.Telefone.Name = "Telefone";
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.FillWeight = 150F;
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.Width = 150;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "Modelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.Width = 250;
            // 
            // Ano
            // 
            this.Ano.DataPropertyName = "Ano";
            this.Ano.HeaderText = "Ano";
            this.Ano.Name = "Ano";
            this.Ano.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pessoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Placa";
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPessoa.Location = new System.Drawing.Point(16, 33);
            this.txtIdPessoa.MaxLength = 20;
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.ReadOnly = true;
            this.txtIdPessoa.Size = new System.Drawing.Size(62, 20);
            this.txtIdPessoa.TabIndex = 0;
            this.txtIdPessoa.TabStop = false;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(16, 82);
            this.txtPlaca.MaxLength = 10;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(62, 20);
            this.txtPlaca.TabIndex = 2;
            this.txtPlaca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlaca_KeyDown);
            this.txtPlaca.Leave += new System.EventHandler(this.txtPlaca_Leave);
            // 
            // txtIdMarca
            // 
            this.txtIdMarca.Location = new System.Drawing.Point(84, 82);
            this.txtIdMarca.MaxLength = 80;
            this.txtIdMarca.Name = "txtIdMarca";
            this.txtIdMarca.ReadOnly = true;
            this.txtIdMarca.Size = new System.Drawing.Size(60, 20);
            this.txtIdMarca.TabIndex = 3;
            this.txtIdMarca.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Marca";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Modelo";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(612, 6);
            this.txtId.MaxLength = 20;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(41, 20);
            this.txtId.TabIndex = 6;
            this.txtId.Visible = false;
            // 
            // txtNomePessoa
            // 
            this.txtNomePessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePessoa.Location = new System.Drawing.Point(84, 33);
            this.txtNomePessoa.Name = "txtNomePessoa";
            this.txtNomePessoa.ReadOnly = true;
            this.txtNomePessoa.Size = new System.Drawing.Size(529, 20);
            this.txtNomePessoa.TabIndex = 1;
            this.txtNomePessoa.TabStop = false;
            // 
            // txtDescMarca
            // 
            this.txtDescMarca.Location = new System.Drawing.Point(150, 82);
            this.txtDescMarca.MaxLength = 80;
            this.txtDescMarca.Name = "txtDescMarca";
            this.txtDescMarca.ReadOnly = true;
            this.txtDescMarca.Size = new System.Drawing.Size(432, 20);
            this.txtDescMarca.TabIndex = 4;
            this.txtDescMarca.TabStop = false;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(16, 126);
            this.txtModelo.MaxLength = 20;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(214, 20);
            this.txtModelo.TabIndex = 5;
            this.txtModelo.TabStop = false;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(236, 126);
            this.txtAno.MaxLength = 20;
            this.txtAno.Name = "txtAno";
            this.txtAno.ReadOnly = true;
            this.txtAno.Size = new System.Drawing.Size(59, 20);
            this.txtAno.TabIndex = 6;
            this.txtAno.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ano";
            // 
            // btnVeiculo
            // 
            this.btnVeiculo.Location = new System.Drawing.Point(588, 80);
            this.btnVeiculo.Name = "btnVeiculo";
            this.btnVeiculo.Size = new System.Drawing.Size(25, 23);
            this.btnVeiculo.TabIndex = 12;
            this.btnVeiculo.TabStop = false;
            this.btnVeiculo.Text = "...";
            this.btnVeiculo.UseVisualStyleBackColor = true;
            this.btnVeiculo.Click += new System.EventHandler(this.btnVeiculo_Click);
            // 
            // txtIdVeiculo
            // 
            this.txtIdVeiculo.Location = new System.Drawing.Point(623, 50);
            this.txtIdVeiculo.Name = "txtIdVeiculo";
            this.txtIdVeiculo.Size = new System.Drawing.Size(30, 20);
            this.txtIdVeiculo.TabIndex = 13;
            this.txtIdVeiculo.Visible = false;
            // 
            // btnCertificado
            // 
            this.btnCertificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCertificado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCertificado.ImageIndex = 0;
            this.btnCertificado.ImageList = this.imageList1;
            this.btnCertificado.Location = new System.Drawing.Point(400, 19);
            this.btnCertificado.Name = "btnCertificado";
            this.btnCertificado.Size = new System.Drawing.Size(92, 34);
            this.btnCertificado.TabIndex = 5;
            this.btnCertificado.Text = "Imprimir";
            this.btnCertificado.UseVisualStyleBackColor = true;
            this.btnCertificado.Click += new System.EventHandler(this.btnCertificado_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Print.png");
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Checked = true;
            this.chkImprimir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimir.Location = new System.Drawing.Point(5, 31);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(61, 17);
            this.chkImprimir.TabIndex = 4;
            this.chkImprimir.Text = "Imprimir";
            this.chkImprimir.UseVisualStyleBackColor = true;
            // 
            // frmPessoaVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(705, 402);
            this.Name = "frmPessoaVeiculo";
            this.Text = "Expositores e seus Veículos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPessoaVeiculo_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPessoaVeiculo_KeyDown);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdMarca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNomePessoa;
        private System.Windows.Forms.TextBox txtDescMarca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Button btnVeiculo;
        private System.Windows.Forms.TextBox txtIdVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ano;
        private System.Windows.Forms.Button btnCertificado;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkImprimir;
    }
}
