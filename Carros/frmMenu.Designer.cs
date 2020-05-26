namespace Carros
{
    partial class frmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expositoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expositoresVisitantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeSóciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profissõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automóveisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sairDoSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encontrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenciaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaDeControleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeEncontrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarEmailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarCertificadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExpositores = new System.Windows.Forms.Button();
            this.btnAutomovel = new System.Windows.Forms.Button();
            this.btnEncontro = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.rodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.encontrosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.utilitáriosToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 50);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(828, 70);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expositoresToolStripMenuItem,
            this.expositoresVisitantesToolStripMenuItem,
            this.cadastroDeSóciosToolStripMenuItem,
            this.cidadesToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.profissõesToolStripMenuItem,
            this.automóveisToolStripMenuItem,
            this.toolStripMenuItem1,
            this.usuáriosToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sairDoSistemaToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(84, 18);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // expositoresToolStripMenuItem
            // 
            this.expositoresToolStripMenuItem.Name = "expositoresToolStripMenuItem";
            this.expositoresToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.expositoresToolStripMenuItem.Text = "Expositores Sócios";
            this.expositoresToolStripMenuItem.Click += new System.EventHandler(this.expositoresToolStripMenuItem_Click);
            // 
            // expositoresVisitantesToolStripMenuItem
            // 
            this.expositoresVisitantesToolStripMenuItem.Name = "expositoresVisitantesToolStripMenuItem";
            this.expositoresVisitantesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.expositoresVisitantesToolStripMenuItem.Text = "Expositores Visitantes";
            this.expositoresVisitantesToolStripMenuItem.Click += new System.EventHandler(this.expositoresVisitantesToolStripMenuItem_Click);
            // 
            // cadastroDeSóciosToolStripMenuItem
            // 
            this.cadastroDeSóciosToolStripMenuItem.Name = "cadastroDeSóciosToolStripMenuItem";
            this.cadastroDeSóciosToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.cadastroDeSóciosToolStripMenuItem.Text = "Cadastro de Sócios";
            this.cadastroDeSóciosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeSóciosToolStripMenuItem_Click);
            // 
            // cidadesToolStripMenuItem
            // 
            this.cidadesToolStripMenuItem.Name = "cidadesToolStripMenuItem";
            this.cidadesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.cidadesToolStripMenuItem.Text = "Cidades";
            this.cidadesToolStripMenuItem.Click += new System.EventHandler(this.cidadesToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // profissõesToolStripMenuItem
            // 
            this.profissõesToolStripMenuItem.Name = "profissõesToolStripMenuItem";
            this.profissõesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.profissõesToolStripMenuItem.Text = "Profissões";
            this.profissõesToolStripMenuItem.Click += new System.EventHandler(this.profissõesToolStripMenuItem_Click);
            // 
            // automóveisToolStripMenuItem
            // 
            this.automóveisToolStripMenuItem.Name = "automóveisToolStripMenuItem";
            this.automóveisToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.automóveisToolStripMenuItem.Text = "Automóveis";
            this.automóveisToolStripMenuItem.Click += new System.EventHandler(this.automóveisToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.Click += new System.EventHandler(this.usuáriosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(211, 6);
            // 
            // sairDoSistemaToolStripMenuItem
            // 
            this.sairDoSistemaToolStripMenuItem.Name = "sairDoSistemaToolStripMenuItem";
            this.sairDoSistemaToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sairDoSistemaToolStripMenuItem.Text = "Sair do Sistema";
            this.sairDoSistemaToolStripMenuItem.Click += new System.EventHandler(this.sairDoSistemaToolStripMenuItem_Click);
            // 
            // encontrosToolStripMenuItem
            // 
            this.encontrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lançamentosToolStripMenuItem});
            this.encontrosToolStripMenuItem.Name = "encontrosToolStripMenuItem";
            this.encontrosToolStripMenuItem.Size = new System.Drawing.Size(82, 18);
            this.encontrosToolStripMenuItem.Text = "Encontros";
            // 
            // lançamentosToolStripMenuItem
            // 
            this.lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            this.lançamentosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.lançamentosToolStripMenuItem.Text = "Lançamentos";
            this.lançamentosToolStripMenuItem.Click += new System.EventHandler(this.lançamentosToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequenciaisToolStripMenuItem,
            this.tabelaDeControleToolStripMenuItem,
            this.cadastroDeEncontrosToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(109, 18);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // sequenciaisToolStripMenuItem
            // 
            this.sequenciaisToolStripMenuItem.Name = "sequenciaisToolStripMenuItem";
            this.sequenciaisToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sequenciaisToolStripMenuItem.Text = "Sequenciais";
            this.sequenciaisToolStripMenuItem.Click += new System.EventHandler(this.sequenciaisToolStripMenuItem_Click);
            // 
            // tabelaDeControleToolStripMenuItem
            // 
            this.tabelaDeControleToolStripMenuItem.Name = "tabelaDeControleToolStripMenuItem";
            this.tabelaDeControleToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.tabelaDeControleToolStripMenuItem.Text = "Tabela de Controle";
            this.tabelaDeControleToolStripMenuItem.Click += new System.EventHandler(this.tabelaDeControleToolStripMenuItem_Click);
            // 
            // cadastroDeEncontrosToolStripMenuItem
            // 
            this.cadastroDeEncontrosToolStripMenuItem.Name = "cadastroDeEncontrosToolStripMenuItem";
            this.cadastroDeEncontrosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.cadastroDeEncontrosToolStripMenuItem.Text = "Cadastro de Encontros";
            this.cadastroDeEncontrosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeEncontrosToolStripMenuItem_Click);
            // 
            // utilitáriosToolStripMenuItem
            // 
            this.utilitáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarEmailsToolStripMenuItem,
            this.configurarCertificadoToolStripMenuItem});
            this.utilitáriosToolStripMenuItem.Name = "utilitáriosToolStripMenuItem";
            this.utilitáriosToolStripMenuItem.Size = new System.Drawing.Size(78, 18);
            this.utilitáriosToolStripMenuItem.Text = "Utilitários";
            // 
            // exportarEmailsToolStripMenuItem
            // 
            this.exportarEmailsToolStripMenuItem.Name = "exportarEmailsToolStripMenuItem";
            this.exportarEmailsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exportarEmailsToolStripMenuItem.Text = "Exportar Emails";
            this.exportarEmailsToolStripMenuItem.Click += new System.EventHandler(this.exportarEmailsToolStripMenuItem_Click);
            // 
            // configurarCertificadoToolStripMenuItem
            // 
            this.configurarCertificadoToolStripMenuItem.Name = "configurarCertificadoToolStripMenuItem";
            this.configurarCertificadoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.configurarCertificadoToolStripMenuItem.Text = "Configurar Certificado";
            this.configurarCertificadoToolStripMenuItem.Click += new System.EventHandler(this.configurarCertificadoToolStripMenuItem_Click);
            // 
            // btnExpositores
            // 
            this.btnExpositores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpositores.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpositores.Location = new System.Drawing.Point(3, 3);
            this.btnExpositores.Name = "btnExpositores";
            this.btnExpositores.Size = new System.Drawing.Size(125, 34);
            this.btnExpositores.TabIndex = 2;
            this.btnExpositores.Text = "Visitantes";
            this.btnExpositores.UseVisualStyleBackColor = true;
            this.btnExpositores.Click += new System.EventHandler(this.btnExpositores_Click);
            // 
            // btnAutomovel
            // 
            this.btnAutomovel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutomovel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutomovel.Location = new System.Drawing.Point(3, 43);
            this.btnAutomovel.Name = "btnAutomovel";
            this.btnAutomovel.Size = new System.Drawing.Size(125, 34);
            this.btnAutomovel.TabIndex = 3;
            this.btnAutomovel.Text = "Automóveis";
            this.btnAutomovel.UseVisualStyleBackColor = true;
            this.btnAutomovel.Click += new System.EventHandler(this.btnAutomovel_Click);
            // 
            // btnEncontro
            // 
            this.btnEncontro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncontro.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncontro.Location = new System.Drawing.Point(3, 83);
            this.btnEncontro.Name = "btnEncontro";
            this.btnEncontro.Size = new System.Drawing.Size(125, 34);
            this.btnEncontro.TabIndex = 4;
            this.btnEncontro.Text = "Encontros";
            this.btnEncontro.UseVisualStyleBackColor = true;
            this.btnEncontro.Click += new System.EventHandler(this.btnEncontro_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.Silver;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rodape});
            this.StatusBar.Location = new System.Drawing.Point(0, 435);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(828, 22);
            this.StatusBar.TabIndex = 6;
            this.StatusBar.Text = "statusStrip1";
            // 
            // rodape
            // 
            this.rodape.Name = "rodape";
            this.rodape.Size = new System.Drawing.Size(41, 17);
            this.rodape.Text = "Versao";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanel1.Controls.Add(this.btnExpositores);
            this.flowLayoutPanel1.Controls.Add(this.btnAutomovel);
            this.flowLayoutPanel1.Controls.Add(this.btnEncontro);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(137, 365);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 457);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expositoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expositoresVisitantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeSóciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profissõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automóveisToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sairDoSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encontrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenciaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaDeControleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeEncontrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarEmailsToolStripMenuItem;
        private System.Windows.Forms.Button btnExpositores;
        private System.Windows.Forms.Button btnAutomovel;
        private System.Windows.Forms.Button btnEncontro;
        private System.Windows.Forms.ToolStripMenuItem configurarCertificadoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel rodape;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}