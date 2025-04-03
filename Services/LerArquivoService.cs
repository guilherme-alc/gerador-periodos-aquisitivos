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
                for (int linha = 3; linha <= totalLinhas; linha++)
                {
                    var funcionario = new Funcionario
                    {
                        CodEmpresa = planilha.Cells[linha, 1].Text,
                        CpfFuncionario = planilha.Cells[linha, 2].Text,
                        DataAdmissao = DateTime.Parse(planilha.Cells[linha, 3].Text)
                    };

                    funcionarios.Add(funcionario);
                }
            }

            return funcionarios;
        }
    }
}
