using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using FEDeksamenMaui.Models;
using FEDeksamenMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        //check debtbook for observablecollection etc.
        public ObservableCollection<Order> OrdersForSelectedDate { get; set; } = new();

        [ObservableProperty]

        private DateOnly? _selectedDate;

        private readonly IDatabase _database;

        public CalendarViewModel(IDatabase database)
        {
            _database = database;
            _ = Initialize();
        }

        private async Task Initialize()
        {
            //check debtbook for example on implementation here
        }

        [RelayCommand]
        public async Task GoToInvoice()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InvoicePage());
        }

        [RelayCommand]
        public async Task ShowTasks()
        {
            try
            {
                var orders = await _database.GetOrdersForSelectedDate(_selectedDate.Value);

                foreach(var order in orders)
                {
                    OrdersForSelectedDate.Add(order);
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exp while showing orders for date: " + ex.Message);
            }
    
        }
    }


}
