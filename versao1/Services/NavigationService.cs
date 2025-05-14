using System;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HealthDiary.Services;

public class NavigationService : ObservableObject
{
    private UserControl? _currentView;
    public UserControl? CurrentView
    {
        get => _currentView;
        private set => SetProperty(ref _currentView, value);
    }

    private static NavigationService? _instance;
    public static NavigationService Instance => _instance ??= new NavigationService();

    private NavigationService() { }

    public event EventHandler<UserControl?>? NavigationChanged;

    public void Initialize(ContentControl contentControl)
    {
        // This method is now empty as the initialization is handled in the constructor
    }

    public void NavigateTo<T>(T view) where T : UserControl
    {
        CurrentView = view;
        NavigationChanged?.Invoke(this, view);
    }

    public void NavigateTo(UserControl view)
    {
        CurrentView = view;
        NavigationChanged?.Invoke(this, view);
    }
} 