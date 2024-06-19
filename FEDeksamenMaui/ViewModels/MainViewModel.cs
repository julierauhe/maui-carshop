using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using FEDeksamenMaui.Models;
using FEDeksamenMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Model1> Model1Items { get; set; } = new();

        [ObservableProperty]
        private Model1? _selectedItem;

        private readonly IDatabase _database;

        public MainViewModel(IDatabase database)
        {
            _database = database;
            Initialize();
        }

        private async Task Initialize()
        {
            //await GetAllPizzas(); or get whatever should be on mainpage

            //await Task.CompletedTask;
        }

        [RelayCommand]
        public async Task OnCounterClicked()
        {
            //implement what happens when command is 'activated'
        }

        [RelayCommand]
        public async Task GoToNewPage1()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewPage1());
        }
    }
}
