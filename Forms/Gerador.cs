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
        try
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
                List<Funcionario> funcionarios = LerArquivoService.DesserializarLinhas(caminhoArquivo);

                foreach (var funcionario in funcionarios)
                {
                    var periodos = GerarPeriodoService.CalcularPeriodo(funcionario);
                    funcionario.PeriodosAquisitivos = periodos;
                }

                var sucesso = GravarArquivoService.SerializarPeriodos(funcionarios);

                MessageBox.Show(sucesso, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Informações inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}