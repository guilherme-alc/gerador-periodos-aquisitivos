namespace GeradorPeriodosAquisitivos;

partial class Gerador
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gerador));
        btnImportar = new Button();
        openFileDialog = new OpenFileDialog();
        txtCaminhoArquivo = new TextBox();
        menuPrincipal = new MenuStrip();
        arquivoMenuItem = new ToolStripMenuItem();
        selecionarPlanilhaMenuItem = new ToolStripMenuItem();
        salvarPlanilhaModeloMenuItem = new ToolStripMenuItem();
        sairMenuItem = new ToolStripMenuItem();
        grupoSelecao = new GroupBox();
        dgvPrevisualizacao = new DataGridView();
        grupoPrevisualizacao = new GroupBox();
        grupoEmpresa = new GroupBox();
        txtNomeArquivo = new TextBox();
        btnLimpar = new Button();
        grupoLimpar = new GroupBox();
        errorProvider = new ErrorProvider(components);
        helpProvider = new HelpProvider();
        menuPrincipal.SuspendLayout();
        grupoSelecao.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPrevisualizacao).BeginInit();
        grupoPrevisualizacao.SuspendLayout();
        grupoEmpresa.SuspendLayout();
        grupoLimpar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // btnImportar
        // 
        btnImportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnImportar.BackColor = Color.Firebrick;
        btnImportar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnImportar.ForeColor = Color.White;
        btnImportar.Location = new Point(588, 16);
        btnImportar.Margin = new Padding(3, 2, 3, 2);
        btnImportar.Name = "btnImportar";
        btnImportar.Size = new Size(82, 30);
        btnImportar.TabIndex = 0;
        btnImportar.Text = "Gerar";
        btnImportar.UseVisualStyleBackColor = false;
        btnImportar.Click += ImportarArquivo;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog";
        // 
        // txtCaminhoArquivo
        // 
        txtCaminhoArquivo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtCaminhoArquivo.Location = new Point(6, 21);
        txtCaminhoArquivo.Margin = new Padding(3, 2, 3, 2);
        txtCaminhoArquivo.Name = "txtCaminhoArquivo";
        txtCaminhoArquivo.Size = new Size(563, 23);
        txtCaminhoArquivo.TabIndex = 1;
        // 
        // menuPrincipal
        // 
        menuPrincipal.BackColor = Color.Firebrick;
        menuPrincipal.Items.AddRange(new ToolStripItem[] { arquivoMenuItem, sairMenuItem });
        menuPrincipal.Location = new Point(0, 0);
        menuPrincipal.Name = "menuPrincipal";
        menuPrincipal.Size = new Size(700, 24);
        menuPrincipal.TabIndex = 1;
        menuPrincipal.Text = "menuPrincipal";
        // 
        // arquivoMenuItem
        // 
        arquivoMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selecionarPlanilhaMenuItem, salvarPlanilhaModeloMenuItem });
        arquivoMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        arquivoMenuItem.ForeColor = Color.White;
        arquivoMenuItem.Name = "arquivoMenuItem";
        arquivoMenuItem.Size = new Size(61, 20);
        arquivoMenuItem.Text = "Arquivo";
        // 
        // selecionarPlanilhaMenuItem
        // 
        selecionarPlanilhaMenuItem.BackColor = Color.Firebrick;
        selecionarPlanilhaMenuItem.ForeColor = Color.White;
        selecionarPlanilhaMenuItem.Name = "selecionarPlanilhaMenuItem";
        selecionarPlanilhaMenuItem.Size = new Size(195, 22);
        selecionarPlanilhaMenuItem.Text = "Selecionar Planilha";
        selecionarPlanilhaMenuItem.Click += SelecionarPlanilha;
        // 
        // salvarPlanilhaModeloMenuItem
        // 
        salvarPlanilhaModeloMenuItem.BackColor = Color.Firebrick;
        salvarPlanilhaModeloMenuItem.ForeColor = Color.White;
        salvarPlanilhaModeloMenuItem.Name = "salvarPlanilhaModeloMenuItem";
        salvarPlanilhaModeloMenuItem.Size = new Size(195, 22);
        salvarPlanilhaModeloMenuItem.Text = "Baixar Planilha Modelo";
        salvarPlanilhaModeloMenuItem.Click += BaixarPlanilhaModelo;
        // 
        // sairMenuItem
        // 
        sairMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        sairMenuItem.ForeColor = Color.White;
        sairMenuItem.Name = "sairMenuItem";
        sairMenuItem.Size = new Size(39, 20);
        sairMenuItem.Text = "Sair";
        sairMenuItem.Click += SairAplicacao;
        // 
        // grupoSelecao
        // 
        grupoSelecao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grupoSelecao.Controls.Add(btnImportar);
        grupoSelecao.Controls.Add(txtCaminhoArquivo);
        grupoSelecao.Location = new Point(12, 86);
        grupoSelecao.Name = "grupoSelecao";
        grupoSelecao.Size = new Size(676, 51);
        grupoSelecao.TabIndex = 4;
        grupoSelecao.TabStop = false;
        grupoSelecao.Text = "Caminho do Arquivo";
        // 
        // dgvPrevisualizacao
        // 
        dgvPrevisualizacao.BackgroundColor = SystemColors.ControlLightLight;
        dgvPrevisualizacao.BorderStyle = BorderStyle.Fixed3D;
        dgvPrevisualizacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPrevisualizacao.Dock = DockStyle.Fill;
        dgvPrevisualizacao.Location = new Point(3, 19);
        dgvPrevisualizacao.Name = "dgvPrevisualizacao";
        dgvPrevisualizacao.Size = new Size(670, 281);
        dgvPrevisualizacao.TabIndex = 0;
        // 
        // grupoPrevisualizacao
        // 
        grupoPrevisualizacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grupoPrevisualizacao.Controls.Add(dgvPrevisualizacao);
        grupoPrevisualizacao.Location = new Point(12, 143);
        grupoPrevisualizacao.Name = "grupoPrevisualizacao";
        grupoPrevisualizacao.Size = new Size(676, 303);
        grupoPrevisualizacao.TabIndex = 6;
        grupoPrevisualizacao.TabStop = false;
        grupoPrevisualizacao.Text = "Pré-visualização dos Períodos Gerados";
        // 
        // grupoEmpresa
        // 
        grupoEmpresa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        grupoEmpresa.Controls.Add(txtNomeArquivo);
        grupoEmpresa.Location = new Point(12, 30);
        grupoEmpresa.Name = "grupoEmpresa";
        grupoEmpresa.Size = new Size(569, 50);
        grupoEmpresa.TabIndex = 7;
        grupoEmpresa.TabStop = false;
        grupoEmpresa.Text = "Nome do Arquivo";
        // 
        // txtNomeArquivo
        // 
        txtNomeArquivo.Location = new Point(6, 20);
        txtNomeArquivo.Name = "txtNomeArquivo";
        txtNomeArquivo.Size = new Size(303, 23);
        txtNomeArquivo.TabIndex = 0;
        // 
        // btnLimpar
        // 
        btnLimpar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLimpar.BackColor = Color.Gray;
        btnLimpar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnLimpar.ForeColor = Color.White;
        btnLimpar.Location = new Point(7, 13);
        btnLimpar.Margin = new Padding(3, 2, 3, 2);
        btnLimpar.Name = "btnLimpar";
        btnLimpar.Size = new Size(82, 30);
        btnLimpar.TabIndex = 8;
        btnLimpar.Text = "Limpar";
        btnLimpar.UseVisualStyleBackColor = false;
        btnLimpar.Click += LimparCampos;
        // 
        // grupoLimpar
        // 
        grupoLimpar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        grupoLimpar.Controls.Add(btnLimpar);
        grupoLimpar.Location = new Point(593, 30);
        grupoLimpar.Name = "grupoLimpar";
        grupoLimpar.Size = new Size(95, 50);
        grupoLimpar.TabIndex = 1;
        grupoLimpar.TabStop = false;
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // Gerador
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 458);
        Controls.Add(grupoLimpar);
        Controls.Add(grupoEmpresa);
        Controls.Add(grupoPrevisualizacao);
        Controls.Add(grupoSelecao);
        Controls.Add(menuPrincipal);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = menuPrincipal;
        Margin = new Padding(3, 2, 3, 2);
        MinimumSize = new Size(716, 377);
        Name = "Gerador";
        Text = "Gerador de Períodos Aquisitivos";
        WindowState = FormWindowState.Maximized;
        Load += CarregaFormulario;
        menuPrincipal.ResumeLayout(false);
        menuPrincipal.PerformLayout();
        grupoSelecao.ResumeLayout(false);
        grupoSelecao.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPrevisualizacao).EndInit();
        grupoPrevisualizacao.ResumeLayout(false);
        grupoEmpresa.ResumeLayout(false);
        grupoEmpresa.PerformLayout();
        grupoLimpar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnImportar;
    private OpenFileDialog openFileDialog;
    private TextBox txtCaminhoArquivo;
    private MenuStrip menuPrincipal;
    private ToolStripMenuItem arquivoMenuItem;
    private ToolStripMenuItem salvarPlanilhaModeloMenuItem;
    private ToolStripMenuItem sairMenuItem;
    private GroupBox grupoSelecao;
    private DataGridView dgvPrevisualizacao;
    private GroupBox grupoPrevisualizacao;
    private ToolStripMenuItem selecionarPlanilhaMenuItem;
    private GroupBox grupoEmpresa;
    private TextBox txtNomeArquivo;
    private Button btnLimpar;
    private GroupBox grupoLimpar;
    private ErrorProvider errorProvider;
    private HelpProvider helpProvider;
}