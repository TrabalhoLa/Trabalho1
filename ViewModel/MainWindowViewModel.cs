using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Services;

namespace Trabalho1.ViewModel;

public class MainWindowViewModel : ReactiveObject
{
    private readonly DatabaseService _databaseService;
    private RegistroDiario _registroAtual;
    private ObservableCollection<RegistroCompleto> _registros;
    private DateTime _dataInicio;
    private DateTime _dataFim;

    public MainWindowViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        _registros = new ObservableCollection<RegistroCompleto>();
        _dataInicio = DateTime.Today.AddDays(-30);
        _dataFim = DateTime.Today;

        SalvarCommand = ReactiveCommand.CreateFromTask(SalvarRegistroAsync);
        CarregarRegistrosCommand = ReactiveCommand.CreateFromTask(CarregarRegistrosAsync);
        
        // Inicializa com os dados dos últimos 30 dias
        _ = CarregarRegistrosAsync();
    }

    public ObservableCollection<RegistroCompleto> Registros
    {
        get => _registros;
        set => this.RaiseAndSetIfChanged(ref _registros, value);
    }

    public DateTime DataInicio
    {
        get => _dataInicio;
        set
        {
            this.RaiseAndSetIfChanged(ref _dataInicio, value);
            _ = CarregarRegistrosAsync();
        }
    }

    public DateTime DataFim
    {
        get => _dataFim;
        set
        {
            this.RaiseAndSetIfChanged(ref _dataFim, value);
            _ = CarregarRegistrosAsync();
        }
    }

    public ReactiveCommand<Unit, Unit> SalvarCommand { get; }
    public ReactiveCommand<Unit, Unit> CarregarRegistrosCommand { get; }

    private async Task SalvarRegistroAsync()
    {
        try
        {
            var id = await _databaseService.SalvarRegistroDiarioAsync(_registroAtual);
            await CarregarRegistrosAsync();
            // Limpar formulário ou mostrar mensagem de sucesso
        }
        catch (Exception ex)
        {
            // Tratar erro
        }
    }

    private async Task CarregarRegistrosAsync()
    {
        try
        {
            var registros = await _databaseService.ObterRegistrosCompletosAsync(_dataInicio, _dataFim);
            Registros.Clear();
            foreach (var registro in registros)
            {
                Registros.Add(registro);
            }
        }
        catch (Exception ex)
        {
            // Tratar erro
        }
    }
}