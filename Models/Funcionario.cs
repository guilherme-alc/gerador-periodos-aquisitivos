namespace GeradorPeriodosAquisitivos.Models
{
    public class Funcionario
    {
        public string CodEmpresa { get; set; }
        public string CpfFuncionario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public List<PeriodoAquisitivo>? PeriodosAquisitivos { get; set; }
    }
}
