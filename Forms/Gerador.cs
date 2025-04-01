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
            Filter = "Arquivo Excel (*.xlsx)|*.xlsx|Arquivos Excel 97-2003 (*.xls)|*.xls",
            Multiselect = false,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            var caminhoArquivo = openFileDialog.FileName;
            txtCaminhoArquivo.Text = caminhoArquivo;
            List<Funcionario> funcionarios = LerArquivoService.SerializaPeriodos(caminhoArquivo);

            foreach(var funcionario in funcionarios)
            {
                var periodo = GeraPeriodoService.CalculaPeriodo(funcionario);
            }
        }
    }
}