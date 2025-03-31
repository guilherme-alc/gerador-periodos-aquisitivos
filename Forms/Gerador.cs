using GeradorPeriodosAquisitivos.Models;
using GeradorPeriodosAquisitivos.Services;

namespace GeradorPeriodosAquisitivos;

public partial class Gerador : Form
{
    public Gerador()
    {
        InitializeComponent();
    }

    private void CarregaFormulario(object sender, EventArgs e)
    {
        txtCaminhoArquivo.Enabled = false;
    }

    private void ImportarArquivo(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "Selecione o arquivo Excel",
            Filter = "Arquivo .xlsx|*.xlsx",
            Multiselect = false,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtCaminhoArquivo.Text = openFileDialog.FileName;
        }
    }
}