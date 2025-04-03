using GeradorPeriodosAquisitivos.Models;
using OfficeOpenXml;

namespace GeradorPeriodosAquisitivos.Services
{
    public class GravarArquivoService
    {
        public static void AdicionarRegistros(List<Funcionario> funcionarios)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Guilherme Campos");
                using (var package = new ExcelPackage())
                {
                    var planilha = package.Workbook.Worksheets.Add("Planilha1");

                    planilha.Cells["A1"].Value = "Férias";
                    planilha.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    planilha.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    using (var range = planilha.Cells["A1:J1"])
                    {
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#B4C6E7"));
                    }

                    planilha.Cells["A2"].Value = "Identificador Empresa";
                    planilha.Cells["B2"].Value = "CpfFuncionario";
                    planilha.Cells["C2"].Value = "Inicio do periodo Aquisitivo";
                    planilha.Cells["D2"].Value = "Fim do periodo Aquisitivo";
                    using (var range = planilha.Cells["A2:D2"])
                        range.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#FF0000"));

                    planilha.Cells["E2"].Value = "Inicio do gozo ";
                    planilha.Cells["F2"].Value = "Fim do gozo ";
                    planilha.Cells["G2"].Value = "Dias de férias ";
                    planilha.Cells["H2"].Value = "Data Retorno ";
                    planilha.Cells["I2"].Value = "Data Pagamento";
                    using (var range = planilha.Cells["E2:I2"])
                        range.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#FFC000"));

                    planilha.Cells["J2"].Value = "Status";
                    planilha.Cells["J2"].Style.Font.Color.SetColor(ColorTranslator.FromHtml("#00B0F0"));


                    int linha = 3;
                    foreach (var funcionario in funcionarios)
                    {
                        if(funcionario.PeriodosAquisitivos.Count > 0)
                        {
                            foreach (var periodo in funcionario.PeriodosAquisitivos)
                            {
                                planilha.Cells[linha, 1].Value = funcionario.CodEmpresa;
                                planilha.Cells[linha, 2].Value = funcionario.CpfFuncionario;
                                
                                planilha.Cells[linha, 3].Value = periodo.DataInicioPeriodo;
                                planilha.Cells[linha, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                             
                                planilha.Cells[linha, 4].Value = periodo.DataFimPeriodo;
                                planilha.Cells[linha, 4].Style.Numberformat.Format = "dd/MM/yyyy";

                                planilha.Cells[linha, 5].Style.Numberformat.Format = "dd/MM/yyyy";
                                planilha.Cells[linha, 6].Style.Numberformat.Format = "dd/MM/yyyy";
                                planilha.Cells[linha, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                                planilha.Cells[linha, 9].Style.Numberformat.Format = "dd/MM/yyyy";

                                planilha.Cells[linha, 10].Value = "Preparada";
                                linha++;
                            }
                        }
                        else
                        {
                            planilha.Cells[linha, 1].Value = funcionario.CodEmpresa;
                            planilha.Cells[linha, 2].Value = funcionario.CpfFuncionario;
                            planilha.Cells[linha, 10].Value = "Preparada";
                            linha++;
                        }   
                    }

                    planilha.Cells.AutoFitColumns();

                    string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PlanilhaFerias.xlsx");
                    File.WriteAllBytes(caminhoArquivo, package.GetAsByteArray());
                }    
            } 
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao gerar o arquivo. {ex.Message}");
            }
        }
    }
}
