using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using FEDeksamenMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class InvoiceViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mechanicName;

        [ObservableProperty]
        private float hoursUsed;

        [ObservableProperty]
        private decimal price;

        public ObservableCollection<MaterialViewModel> MaterialsUsed { get; set; } = new();

        private readonly IDatabase _database;

        public InvoiceViewModel(IDatabase database)
        {
            _database = database;
            _ = Initialize();
        }

        private async Task Initialize()
        {
            MaterialsUsed.Add(new MaterialViewModel());
        }

        [RelayCommand]
        private void AddMaterial()
        {
            MaterialsUsed.Add(new MaterialViewModel());
        }

        [RelayCommand]
        public async Task SaveInvoice()
        {
            try
            {
                var materials = MaterialsUsed
                    .Select(m => new Dictionary<string, decimal> { { m.Name, m.Price } })
                    .ToList();

                var invoice = new Invoice
                {
                    MechanicName = MechanicName,
                    MaterialsUsed = materials,
                    HoursUsed = HoursUsed,
                    Price = Price
                };

                var status = await _database.SaveNewInvoice(invoice);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception saving new order: " + ex.Message);
            }
        }
    }
    public partial class MaterialViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private decimal price;
    }
}
