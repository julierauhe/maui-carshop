using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class InvoiceViewModel : ObservableObject
    {
        //check debtbook for observablecollection etc.

        private readonly IDatabase _database;

        public InvoiceViewModel(IDatabase database)
        {
            _database = database;
            _ = Initialize();
        }

        private async Task Initialize()
        {
            //not sure anything should happen here
        }

        [RelayCommand]
        public async Task OnCreateInvoice()
        {
            //save invoice to database
        }


        private void OnMaterialSelected(object sender, EventArgs e)
        {
            //if (sender is Picker picker && picker.SelectedItem is string selectedMaterial)
            //{
            //    var viewModel = (InvoiceViewModel)BindingContext;
            //    if (!viewModel.SelectedMaterials.Contains(selectedMaterial))
            //    {
            //        viewModel.SelectedMaterials.Add(selectedMaterial);
            //    }
            //}
        }
    }
}
