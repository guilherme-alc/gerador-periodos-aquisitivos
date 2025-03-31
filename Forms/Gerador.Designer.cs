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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gerador));
        btnImportar = new Button();
        openFileDialog = new OpenFileDialog();
        txtCaminhoArquivo = new TextBox();
        lblCaminhoArquivo = new Label();
        SuspendLayout();
        // 
        // btnImportar
        // 
        btnImportar.Location = new Point(694, 12);
        btnImportar.Name = "btnImportar";
        btnImportar.Size = new Size(94, 29);
        btnImportar.TabIndex = 0;
        btnImportar.Text = "Importar";
        btnImportar.UseVisualStyleBackColor = true;
        btnImportar.Click += ImportarArquivo;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog";
        // 
        // txtCaminhoArquivo
        // 
        txtCaminhoArquivo.Location = new Point(164, 13);
        txtCaminhoArquivo.Name = "txtCaminhoArquivo";
        txtCaminhoArquivo.Size = new Size(524, 27);
        txtCaminhoArquivo.TabIndex = 1;
        // 
        // lblCaminhoArquivo
        // 
        lblCaminhoArquivo.AutoSize = true;
        lblCaminhoArquivo.Location = new Point(12, 16);
        lblCaminhoArquivo.Name = "lblCaminhoArquivo";
        lblCaminhoArquivo.Size = new Size(146, 20);
        lblCaminhoArquivo.TabIndex = 2;
        lblCaminhoArquivo.Text = "Caminho do Arquivo";
        // 
        // Gerador
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(lblCaminhoArquivo);
        Controls.Add(txtCaminhoArquivo);
        Controls.Add(btnImportar);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Gerador";
        Text = "Gerador De Períodos Aquisitivos";
        Load += this.CarregaFormulario;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnImportar;
    private OpenFileDialog openFileDialog;
    private TextBox txtCaminhoArquivo;
    private Label lblCaminhoArquivo;
}