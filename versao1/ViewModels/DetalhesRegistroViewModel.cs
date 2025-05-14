using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthDiary.Models;
using HealthDiary.Services;
using HealthDiary.Data;
using Avalonia.Controls;
using LinqToDB;

namespace HealthDiary.ViewModels;

public partial class DetalhesRegistroViewModel : ObservableObject
{
    private readonly HealthDiaryDb _db;
    private readonly MainWindowViewModel _mainViewModel;

    [ObservableProperty]
    private RegistroDiario _registro;

    [ObservableProperty]
    private bool _modoEdicao;

    [ObservableProperty]
    private ObservableCollection<Humor> _humores = new();

    [ObservableProperty]
    private ObservableCollection<QualidadeSono> _qualidadesSono = new();

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

    public DetalhesRegistroViewModel(RegistroDiario registro, HealthDiaryDb db)
    {
        _db = db;
        _registro = registro;
        _mainViewModel = App.Current.MainWindow.DataContext as MainWindowViewModel ?? throw new InvalidOperationException("MainViewModel not found");
        
        // Inicializar campos de edição
        HumorSelecionado = registro.Humor;
        SonoSelecionado = registro.Sono;
        DescricaoAlimentacao = registro.Alimentacao?.Descricao ?? string.Empty;
        TipoAtividade = registro.AtividadeFisica?.TipoAtividade ?? string.Empty;
        DuracaoMinutos = registro.AtividadeFisica?.DuracaoMinutos ?? 0;

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
    private void Editar()
    {
        ModoEdicao = true;
    }

    [RelayCommand]
    private async Task Salvar()
    {
        if (HumorSelecionado == null || SonoSelecionado == null)
        {
            // TODO: Show error message
            return;
        }

        // Atualizar Alimentação
        await _db.Alimentacoes
            .Where(a => a.Id == Registro.AlimentacaoId)
            .Set(a => a.Descricao, DescricaoAlimentacao)
            .UpdateAsync();

        // Atualizar Atividade Física
        await _db.AtividadesFisicas
            .Where(a => a.Id == Registro.AtividadeFisicaId)
            .Set(a => a.TipoAtividade, TipoAtividade)
            .Set(a => a.DuracaoMinutos, DuracaoMinutos)
            .UpdateAsync();

        // Atualizar Registro
        await _db.RegistrosDiarios
            .Where(r => r.Id == Registro.Id)
            .Set(r => r.HumorId, HumorSelecionado.Id)
            .Set(r => r.SonoId, SonoSelecionado.Id)
            .UpdateAsync();

        // Recarregar o registro atualizado
        var registroAtualizado = await _db.RegistrosDiarios
            .LoadWith(r => r.Humor)
            .LoadWith(r => r.Sono)
            .LoadWith(r => r.Alimentacao)
            .LoadWith(r => r.AtividadeFisica)
            .FirstOrDefaultAsync(r => r.Id == Registro.Id);

        if (registroAtualizado != null)
        {
            Registro = registroAtualizado;
        }

        await _mainViewModel.LoadDataAsync();
        ModoEdicao = false;
    }

    [RelayCommand]
    private void Cancelar()
    {
        // Restaurar valores originais
        HumorSelecionado = Registro.Humor;
        SonoSelecionado = Registro.Sono;
        DescricaoAlimentacao = Registro.Alimentacao?.Descricao ?? string.Empty;
        TipoAtividade = Registro.AtividadeFisica?.TipoAtividade ?? string.Empty;
        DuracaoMinutos = Registro.AtividadeFisica?.DuracaoMinutos ?? 0;

        ModoEdicao = false;
    }

    [RelayCommand]
    private void Voltar()
    {
        NavigationService.Instance.NavigateTo<UserControl>(null!);
    }
} 