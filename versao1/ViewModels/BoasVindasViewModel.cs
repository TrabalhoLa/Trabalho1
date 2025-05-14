using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthDiary.Data;
using HealthDiary.Views;
using HealthDiary.Services;

namespace HealthDiary.ViewModels;

public partial class BoasVindasViewModel : ObservableObject
{
    private readonly HealthDiaryDb _db;

    public BoasVindasViewModel(HealthDiaryDb db)
    {
        _db = db;
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
} 