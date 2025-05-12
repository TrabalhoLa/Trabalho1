using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Trabalho1.Models.Relatorio;
using Trabalho1.Services;
using ScottPlot;

namespace Trabalho1.ViewModel;

public class RelatoriosViewModel : ReactiveObject
{
    private readonly DatabaseService _databaseService;
    private DateTime _dataInicio;
    private DateTime _dataFim;
    private RelatorioEstatisticas _dados;
    private string _mensagemErro;
    private bool _estaCarregando;
    private byte[] _graficoAtividades;
    private byte[] _graficoHumores;

    public RelatoriosViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        _dataInicio = DateTime.Today.AddDays(-30);
        _dataFim = DateTime.Today;
        
        AtualizarRelatorioCommand = ReactiveCommand.CreateFromTask(AtualizarRelatorioAsync);
    }

    public DateTime DataInicio
    {
        get => _dataInicio;
        set => this.RaiseAndSetIfChanged(ref _dataInicio, value);
    }

    public DateTime DataFim
    {
        get => _dataFim;
        set => this.RaiseAndSetIfChanged(ref _dataFim, value);
    }

    public byte[] GraficoAtividades
    {
        get => _graficoAtividades;
        private set => this.RaiseAndSetIfChanged(ref _graficoAtividades, value);
    }

    public byte[] GraficoHumores
    {
        get => _graficoHumores;
        private set => this.RaiseAndSetIfChanged(ref _graficoHumores, value);
    }

    public bool EstaCarregando
    {
        get => _estaCarregando;
        private set => this.RaiseAndSetIfChanged(ref _estaCarregando, value);
    }

    public string MensagemErro
    {
        get => _mensagemErro;
        private set => this.RaiseAndSetIfChanged(ref _mensagemErro, value);
    }

    public ReactiveCommand<Unit, Unit> AtualizarRelatorioCommand { get; }

    private async Task AtualizarRelatorioAsync()
    {
        try
        {
            EstaCarregando = true;
            MensagemErro = null;

            _dados = await _databaseService.GerarDadosRelatorioAsync(DataInicio, DataFim);
            AtualizarGraficos();
        }
        catch (Exception ex)
        {
            MensagemErro = $"Erro ao gerar relatório: {ex.Message}";
        }
        finally
        {
            EstaCarregando = false;
        }
    }

    private void AtualizarGraficos()
    {
        // Gráfico de Atividades
        var plotAtividades = new Plot(600, 400);
        if (_dados.DadosAtividade.Any())
        {
            var datas = _dados.DadosAtividade.Select(d => d.Data.ToOADate()).ToArray();
            var minutos = _dados.DadosAtividade.Select(d => d.Valor).ToArray();

            var scatter = plotAtividades.Add.Scatter(datas, minutos);
            plotAtividades.Axes.DateTimeX(true);
            plotAtividades.Title("Minutos de Atividade Física por Dia");
            plotAtividades.YLabel("Minutos");
            plotAtividades.XLabel("Data");
        }
        GraficoAtividades = plotAtividades.GetImageBytes();

        // Gráfico de Humores
        var plotHumores = new Plot(600, 400);
        if (_dados.DadosHumor.Any())
        {
            var humoresPorDia = _dados.DadosHumor
                .GroupBy(d => d.Categoria)
                .Select(g => new { Humor = g.Key, Total = g.Sum(x => x.Valor) })
                .OrderByDescending(x => x.Total)
                .ToList();

            var valores = humoresPorDia.Select(h => h.Total).ToArray();
            var posicoes = Enumerable.Range(0, humoresPorDia.Count).Select(i => (double)i).ToArray();
            var labels = humoresPorDia.Select(h => h.Humor).ToArray();

            var bar = plotHumores.Add.Bars(valores);
            plotHumores.Axes.Bottom.TickLabels.Style(rotation: 45);
            plotHumores.Axes.Bottom.TickLabels.SetNames(labels);
            plotHumores.Title("Distribuição de Humores");
            plotHumores.YLabel("Quantidade");
        }
        GraficoHumores = plotHumores.GetImageBytes();
    }
}