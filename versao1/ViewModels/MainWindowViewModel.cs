using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthDiary.Data;
using HealthDiary.Models;
using HealthDiary.Services;
using HealthDiary.Views;
using LinqToDB;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace HealthDiary.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly HealthDiaryDb _db;

    [ObservableProperty]
    private ObservableCollection<RegistroDiario> _registros = new();

    [ObservableProperty]
    private ObservableCollection<Humor> _humores = new();

    [ObservableProperty]
    private ObservableCollection<QualidadeSono> _qualidadesSono = new();

    [ObservableProperty]
    private bool _isNavigating;

    public MainWindowViewModel()
    {
        _db = new HealthDiaryDb();
        LoadDataAsync().ConfigureAwait(false);
        
        // Configurar o serviço de navegação para atualizar o estado
        NavigationService.Instance.NavigationChanged += (sender, e) =>
        {
            IsNavigating = e != null;
        };
        
        // Mostrar a tela de boas-vindas
        var view = new BoasVindasView
        {
            DataContext = new BoasVindasViewModel(_db)
        };
        NavigationService.Instance.NavigateTo(view);
    }

    public async Task LoadDataAsync()
    {
        var humores = await _db.Humores.ToListAsync();
        var qualidadesSono = await _db.QualidadesSono.ToListAsync();
        var registros = await _db.RegistrosDiarios
            .LoadWith(r => r.Humor)
            .LoadWith(r => r.Sono)
            .LoadWith(r => r.Alimentacao)
            .LoadWith(r => r.AtividadeFisica)
            .ToListAsync();

        Humores = new ObservableCollection<Humor>(humores);
        QualidadesSono = new ObservableCollection<QualidadeSono>(qualidadesSono);
        Registros = new ObservableCollection<RegistroDiario>(registros);
    }

    [RelayCommand]
    private void NovoRegistro()
    {
        var view = new NovoRegistroView
        {
            DataContext = new NovoRegistroViewModel(_db)
        };
        NavigationService.Instance.NavigateTo(view);
    }

    [RelayCommand]
    private void AbrirHistorico()
    {
        var view = new HistoricoView
        {
            DataContext = new HistoricoViewModel(_db)
        };
        NavigationService.Instance.NavigateTo(view);
    }

    [RelayCommand]
    private void AbrirRelatorios()
    {
        // TODO: Implement reports view
    }

    [RelayCommand]
    private void VoltarParaInicio()
    {
        var view = new BoasVindasView
        {
            DataContext = new BoasVindasViewModel(_db)
        };
        NavigationService.Instance.NavigateTo(view);
    }
}
