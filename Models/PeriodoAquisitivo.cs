namespace GeradorPeriodosAquisitivos.Models
{
    public class PeriodoAquisitivo
    {
        public string CodEmpresa { get; set; }
        public string CpfFuncionario { get; set; }
        public DateTime DataInicioPeriodo { get; set; }
        public DateTime DataFimPeriodo { get; set; }
    }
}
