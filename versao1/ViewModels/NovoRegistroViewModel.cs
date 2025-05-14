using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthDiary.Data;
using HealthDiary.Models;
using HealthDiary.Services;
using LinqToDB;

namespace HealthDiary.ViewModels;

public partial class NovoRegistroViewModel : ObservableObject
{
    private readonly HealthDiaryDb _db;
    private readonly MainWindowViewModel _mainViewModel;

    [ObservableProperty]
    private DateTime _data = DateTime.Today;

    [ObservableProperty]
    private Humor? _humorSelecionado;

    [ObservableProperty]
    private QualidadeSono? _sonoSelecionado;

    [ObservableProperty]
    private string _descricaoAlimentacao = string.Empty;

    [ObservableProperty]
    private string _tipoAtividade = string.Empty;

    [ObservableProperty]
    private int _duracaoMinutos;

    [ObservableProperty]
    private ObservableCollection<Humor> _humores = new();

    [ObservableProperty]
    private ObservableCollection<QualidadeSono> _qualidadesSono = new();

    public NovoRegistroViewModel(HealthDiaryDb db)
    {
        _db = db;
        _mainViewModel = App.Current.MainWindow.DataContext as MainWindowViewModel ?? throw new InvalidOperationException("MainViewModel not found");
        LoadDataAsync().ConfigureAwait(false);
    }

    private async Task LoadDataAsync()
    {
        var humores = await _db.Humores.ToListAsync();
        var qualidadesSono = await _db.QualidadesSono.ToListAsync();

        Humores = new ObservableCollection<Humor>(humores);
        QualidadesSono = new ObservableCollection<QualidadeSono>(qualidadesSono);
    }

    [RelayCommand]
    private async Task Salvar()
    {
        if (HumorSelecionado == null || SonoSelecionado == null)
        {
            // TODO: Show error message
            return;
        }

        // Salvar Alimentação
        var alimentacao = new Alimentacao
        {
            Descricao = DescricaoAlimentacao
        };
        var alimentacaoId = await _db.Alimentacoes
            .Value(a => a.Descricao, alimentacao.Descricao)
            .InsertWithInt32IdentityAsync();
        if (!alimentacaoId.HasValue)
        {
            throw new InvalidOperationException("Falha ao inserir alimentação");
        }
        alimentacao.Id = alimentacaoId.Value;

        // Salvar Atividade Física
        var atividadeFisica = new AtividadeFisica
        {
            TipoAtividade = TipoAtividade,
            DuracaoMinutos = DuracaoMinutos
        };
        var atividadeId = await _db.AtividadesFisicas
            .Value(a => a.TipoAtividade, atividadeFisica.TipoAtividade)
            .Value(a => a.DuracaoMinutos, atividadeFisica.DuracaoMinutos)
            .InsertWithInt32IdentityAsync();
        if (!atividadeId.HasValue)
        {
            throw new InvalidOperationException("Falha ao inserir atividade física");
        }
        atividadeFisica.Id = atividadeId.Value;

        // Salvar Registro Diário
        var registro = new RegistroDiario
        {
            Data = Data,
            HumorId = HumorSelecionado.Id,
            SonoId = SonoSelecionado.Id,
            AlimentacaoId = alimentacao.Id,
            AtividadeFisicaId = atividadeFisica.Id
        };
        await _db.RegistrosDiarios
            .Value(r => r.Data, registro.Data)
            .Value(r => r.HumorId, registro.HumorId)
            .Value(r => r.SonoId, registro.SonoId)
            .Value(r => r.AlimentacaoId, registro.AlimentacaoId)
            .Value(r => r.AtividadeFisicaId, registro.AtividadeFisicaId)
            .InsertAsync();

        await _mainViewModel.LoadDataAsync();
        VoltarParaInicio();
    }

    [RelayCommand]
    private void Cancelar()
    {
        VoltarParaInicio();
    }

    private void VoltarParaInicio()
    {
        NavigationService.Instance.NavigateTo<UserControl>(null!);
        _mainViewModel.IsNavigating = false;
    }
} 