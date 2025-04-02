using GeradorPeriodosAquisitivos.Models;
using OfficeOpenXml;

namespace GeradorPeriodosAquisitivos.Services
{
    public class LerArquivoService
    {
        public static List<Funcionario> DesserializaLinhas(string caminhoArquivo)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Guilherme Campos");

            List<Funcionario> funcionarios = new List<Funcionario>();

            FileInfo fileInfo = new FileInfo(caminhoArquivo);
            using (var package = new ExcelPackage(fileInfo))
            {
                var primeiraAba = package.Workbook.Worksheets[0];

                int totalLinhas = primeiraAba.Dimension.Rows;
                for (int linha = 3; linha <= totalLinhas; linha++)
                {
                    Funcionario funcionario = new Funcionario
                    {
                        CodEmpresa = primeiraAba.Cells[linha, 1].Text,
                        CpfFuncionario = primeiraAba.Cells[linha, 2].Text,
                        DataAdmissao = DateTime.Parse(primeiraAba.Cells[linha, 3].Text)
                    };

                    funcionarios.Add(funcionario);
                }
            }

            return funcionarios;
        }
    }
}
