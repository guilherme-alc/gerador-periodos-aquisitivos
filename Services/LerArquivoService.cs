using GeradorPeriodosAquisitivos.Models;
using OfficeOpenXml;

namespace GeradorPeriodosAquisitivos.Services
{
    public class LerArquivoService
    {
        public static List<Funcionario> ObterFuncionarios(string caminhoArquivo)
        {
            ExcelPackage.License.SetNonCommercialPersonal("teste");

            List<Funcionario> funcionarios = new List<Funcionario>();

            FileInfo arquivo = new FileInfo(caminhoArquivo);
            using (var package = new ExcelPackage(arquivo))
            {
                var planilha = package.Workbook.Worksheets[0];

                int totalLinhas = planilha.Dimension.Rows;
                for (int linha = 2; linha <= totalLinhas; linha++)
                {
                    var empresa = planilha.Cells[linha, 1].Text.Trim();
                    if(string.IsNullOrEmpty(empresa) || string.IsNullOrWhiteSpace(empresa))
                        throw new ArgumentException($"Código de empresa \"{planilha.Cells[linha, 3].Text}\" inválido.\nLinha {linha}.");

                    var cpf = planilha.Cells[linha, 2].Value.ToString().Trim();
                    if(string.IsNullOrEmpty(cpf) || string.IsNullOrWhiteSpace(cpf))
                        throw new ArgumentException($"CPF \"{planilha.Cells[linha, 3].Text}\" inválido.\nLinha {linha}.");

                    var converteData = DateTime.TryParse(planilha.Cells[linha, 3].Text.Trim(), out var dataAdmissão);
                    if(!converteData)
                    {
                        throw new ArgumentException($"Data de admissão \"{planilha.Cells[linha, 3].Text}\" inválida.\nLinha {linha}.");
                    }
                    var funcionario = new Funcionario
                    {
                        CodEmpresa = empresa,
                        CpfFuncionario = cpf,
                        DataAdmissao = dataAdmissão
                    };

                    funcionarios.Add(funcionario);
                }
            }

            return funcionarios;
        }
    }
}
