using System.Reflection;
using GeradorPeriodosAquisitivos.Models;
using GeradorPeriodosAquisitivos.Services;
using GeradorPeriodosAquisitivos.Style;

namespace GeradorPeriodosAquisitivos;

public partial class Gerador : Form
{
    public Gerador()
    {
        InitializeComponent();
    }

    private void CarregaFormulario(object sender, EventArgs e)
    {
        txtCaminhoArquivo.Text = "Selecione um arquivo xlsx ou xls modelo para geração dos períodos aquisitivos";
        txtCaminhoArquivo.Enabled = false;
        menuPrincipal.RenderMode = ToolStripRenderMode.Professional;
        menuPrincipal.Renderer = new MenuPrincipalRenderer();
    }

    private void ImportarArquivo(object sender, EventArgs e)
    {
        try
        {
            List<Funcionario> funcionarios = LerArquivoService.ObterFuncionarios(txtCaminhoArquivo.Text);

            GerarPeriodoService.AdicionarPeriodos(funcionarios);

            GravarArquivoService.AdicionarRegistros(funcionarios);

            List<PeriodoAquisitivo> todosPeriodosPreview = new();
            foreach (var funcionario in funcionarios)
            {
                if (funcionario.PeriodosAquisitivos.Count > 0)
                {
                    foreach (var periodo in funcionario.PeriodosAquisitivos)
                    {
                        todosPeriodosPreview.Add(periodo);
                    }
                }
            }

            dgvPrevisualizacao.DataSource = todosPeriodosPreview;

            MessageBox.Show("Geração dos períodos realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Informações inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SelecionarPlanilha(object sender, EventArgs e)
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
                txtCaminhoArquivo.Text = openFileDialog.FileName;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Informações inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BaixarPlanilhaModelo(object sender, EventArgs e)
    {
        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "Planilha Excel (*.xlsx)|*.xlsx";
            sfd.FileName = "Modelo.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string resourceName = "GeradorPeriodosAquisitivos.Resources.PlanilhaFerias-Modelo.xlsx";

                using (Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resource == null)
                    {
                        MessageBox.Show("Erro ao localizar o modelo para download.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (FileStream file = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }

                MessageBox.Show($"Planilha modelo salva com sucesso em:\n{sfd.FileName}", "Planilha Salva!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void SairAplicacao(object sender, EventArgs e)
    {
        this.Close();
    }
}