using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthDiary.Data;
using HealthDiary.Models;
using HealthDiary.Services;
using HealthDiary.Views;
using LinqToDB;
using Avalonia.Controls;

namespace HealthDiary.ViewModels;

public partial class HistoricoViewModel : ObservableObject
{
    private readonly HealthDiaryDb _db;
    private readonly MainWindowViewModel _mainViewModel;

    [ObservableProperty]
    private ObservableCollection<RegistroDiario> _registros = new();

    [ObservableProperty]
    private DateTime? _dataInicio;

    [ObservableProperty]
    private DateTime? _dataFim;

    [ObservableProperty]
    private RegistroDiario? _registroSelecionado;

    public HistoricoViewModel(HealthDiaryDb db)
    {
        _db = db;
        _mainViewModel = App.Current.MainWindow.DataContext as MainWindowViewModel ?? throw new InvalidOperationException("MainViewModel not found");
        DataInicio = DateTime.Today.AddDays(-30); // Últimos 30 dias por padrão
        DataFim = DateTime.Today;
        
        // Carrega os dados de forma síncrona no construtor para garantir que estejam disponíveis
        LoadDataAsync().GetAwaiter().GetResult();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            // Primeiro, carregamos os dados relacionados
            var humores = await _db.Humores.ToListAsync();
            var qualidadesSono = await _db.QualidadesSono.ToListAsync();
            var alimentacoes = await _db.Alimentacoes.ToListAsync();
            var atividades = await _db.AtividadesFisicas.ToListAsync();

            // Agora carregamos os registros com os filtros
            IQueryable<RegistroDiario> query = _db.RegistrosDiarios;

            if (DataInicio.HasValue)
                query = query.Where(r => r.Data >= DataInicio.Value.Date);
            
            if (DataFim.HasValue)
                query = query.Where(r => r.Data <= DataFim.Value.Date);

            var registros = await query
                .LoadWith(r => r.Humor)
                .LoadWith(r => r.Sono)
                .LoadWith(r => r.Alimentacao)
                .LoadWith(r => r.AtividadeFisica)
                .OrderByDescending(r => r.Data)
                .ToListAsync();

            Registros = new ObservableCollection<RegistroDiario>(registros);
        }
        catch (Exception ex)
        {
            // Log the error for debugging
            Console.WriteLine($"Error loading data: {ex}");
            throw;
        }
    }

    [RelayCommand]
    private async Task FiltrarRegistros()
    {
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task ExcluirRegistro()
    {
        if (RegistroSelecionado == null) return;

        try
        {
            // Excluir registros relacionados
            await _db.Alimentacoes.DeleteAsync(a => a.Id == RegistroSelecionado.AlimentacaoId);
            await _db.AtividadesFisicas.DeleteAsync(a => a.Id == RegistroSelecionado.AtividadeFisicaId);
            await _db.RegistrosDiarios.DeleteAsync(r => r.Id == RegistroSelecionado.Id);

            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            // Log the error for debugging
            Console.WriteLine($"Error deleting record: {ex}");
            throw;
        }
    }

    [RelayCommand]
    private void VerDetalhes()
    {
        if (RegistroSelecionado == null) return;

        var view = new DetalhesRegistroView
        {
            DataContext = new DetalhesRegistroViewModel(RegistroSelecionado, _db)
        };
        NavigationService.Instance.NavigateTo(view);
    }

    [RelayCommand]
    private void Voltar()
    {
        NavigationService.Instance.NavigateTo<UserControl>(null!);
        _mainViewModel.IsNavigating = false;
    }
} 