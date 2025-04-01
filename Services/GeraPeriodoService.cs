using GeradorPeriodosAquisitivos.Models;

namespace GeradorPeriodosAquisitivos.Services
{
    public static class GeraPeriodoService
    {
        public static List<PeriodoAquisitivo> CalculaPeriodo(Funcionario funcionario)
        {
            var periodos = new List<PeriodoAquisitivo>();
            var dataBase = funcionario.DataAdmissao;

            bool geraPeriodo = false;
            do
            {
                if (dataBase.Year <= DateTime.Now.Year)
                {
                    geraPeriodo = true;

                    var dataFim = dataBase.AddMonths(12).AddDays(-1);

                    var novoPeriodo = new PeriodoAquisitivo
                    {
                        CodEmpresa = funcionario.CodEmpresa,
                        CpfFuncionario = funcionario.CpfFuncionario,
                        DataInicioPeriodo = dataBase,
                        DataFimPeriodo = dataFim
                    };
                    periodos.Add(novoPeriodo);
                    if (dataFim < DateTime.Now)
                        dataBase = dataFim.AddDays(1);
                    else
                        geraPeriodo = false;
                }
                else
                {
                    geraPeriodo = false;
                }

            } while (geraPeriodo);
            return periodos;
        }
    }
}
