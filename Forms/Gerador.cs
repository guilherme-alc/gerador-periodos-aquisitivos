using System.Reflection;
using GeradorPeriodosAquisitivos.Models;
using GeradorPeriodosAquisitivos.Services;
using GeradorPeriodosAquisitivos.Style;

namespace GeradorPeriodosAquisitivos;

public partial class Gerador : Form
{
    private ToolTip toolTip = new ToolTip();
    public Gerador()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += new KeyEventHandler(TabulacaoEnter);
    }

    private void TabulacaoEnter(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }
    }

    private void CarregaFormulario(object sender, EventArgs e)
    {
        toolTip.InitialDelay = 1;

        toolTip.SetToolTip(txtNomeArquivo, "Informe o nome para o arquivo que será gerado.");
        toolTip.SetToolTip(btnLimpar, "Limpar todos os campos e pré-visualização.");
        toolTip.SetToolTip(btnImportar, "Clique aqui para gerar a planilha com os períodos aquisitivos.");
        txtNomeArquivo.Focus();

        helpProvider.SetShowHelp(txtNomeArquivo, true);
        helpProvider.SetHelpString(txtNomeArquivo, "Informe o nome para o arquivo que será gerado.");
       
        txtCaminhoArquivo.Text = "Abra o menu Arquivo e selecione o arquivo xlsx ou xls modelo para geração dos períodos aquisitivos";
        txtCaminhoArquivo.Enabled = false;

        menuPrincipal.RenderMode = ToolStripRenderMode.Professional;
        menuPrincipal.Renderer = new MenuPrincipalRenderer();
    }

    private void ImportarArquivo(object sender, EventArgs e)
    {
        try
        {
            List<Funcionario> funcionarios = LerArquivoService.ObterFuncionarios(txtCaminhoArquivo.Text);

            if (string.IsNullOrEmpty(txtNomeArquivo.Text) || string.IsNullOrWhiteSpace(txtNomeArquivo.Text))
            {
                errorProvider.SetError(txtNomeArquivo, "O nome do arquivo de saída é obrigatório.");
                return;
            }
                
            GerarPeriodoService.AdicionarPeriodos(funcionarios);

            GravarArquivoService.AdicionarRegistros(funcionarios, txtNomeArquivo.Text);

            List<FuncionarioPeriodoDTO> listaExibicao = new List<FuncionarioPeriodoDTO>();

            foreach (var funcionario in funcionarios)
            {
                if (funcionario.PeriodosAquisitivos.Count > 0)
                {
                    foreach (var periodo in funcionario.PeriodosAquisitivos)
                    {
                        listaExibicao.Add(new FuncionarioPeriodoDTO
                        {
                            CodEmpresa = funcionario.CodEmpresa,
                            CpfFuncionario = funcionario.CpfFuncionario,                           
                            DataInicioPeriodo = periodo.DataInicioPeriodo,
                            DataFimPeriodo = periodo.DataFimPeriodo
                        });
                    }
                }
            }

            dgvPrevisualizacao.DataSource = listaExibicao;

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

    private void LimparCampos(object sender, EventArgs e)
    {
        txtCaminhoArquivo.Text = string.Empty;
        txtNomeArquivo.Text = string.Empty;
        dgvPrevisualizacao.DataSource = null;
        dgvPrevisualizacao.Rows.Clear();
    }
}