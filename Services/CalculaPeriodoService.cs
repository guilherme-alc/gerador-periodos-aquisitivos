﻿using GeradorPeriodosAquisitivos.Models;

namespace GeradorPeriodosAquisitivos.Services
{
    public static class CalculaPeriodoService
    {
        public static List<PeriodoAquisitivo> GeraPeriodoService(Funcionario funcionario)
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
                    dataBase = dataFim.AddDays(1);
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
