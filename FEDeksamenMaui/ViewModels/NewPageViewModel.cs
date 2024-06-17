using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class NewPageViewModel : ObservableObject
    {
        //check debtbook for observablecollection etc.

        private readonly Database _database;

        public NewPageViewModel()
        {
            //_database = new Database();
            //_ = Initialize();
        }

        private async Task Initialize()
        {
            //check debtbook for example on implementation here
        }

        [RelayCommand]
        public async Task SomeCommandFromView()
        {
            //implement what happens when command is 'activated'
        }
    }
}
