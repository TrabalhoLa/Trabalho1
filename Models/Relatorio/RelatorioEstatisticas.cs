namespace Trabalho1.Models.Relatorio;

public class RelatorioEstatisticas
{
    public int TotalRegistros { get; set; }
    public double MediaMinutosAtividade { get; set; }
    public List<DadosGrafico> DadosHumor { get; set; } = new();
    public List<DadosGrafico> DadosAtividade { get; set; } = new();
}