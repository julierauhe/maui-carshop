using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using FEDeksamenMaui.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class AddOrderViewModel : ObservableObject
    {
        [ObservableProperty]
        private Order? _selectedItem;

        public string NewCustomerName { get; set; }
        public string NewCustomerAddress { get; set; }
        public string NewCarBrand { get; set; }
        public string NewCarModel { get; set; }
        public string NewRegNumber { get; set; }
        public DateTime NewTimeOfSubmission { get; set; }
        public string NewReperation { get; set; }

        private readonly IDatabase _database;

        public AddOrderViewModel(IDatabase database)
        {
            _database = database;
            Initialize();
        }

        private async Task Initialize()
        {
            NewDate = DateTime.Now.Date;
            NewTime = DateTime.Now.TimeOfDay;
            UpdateTimeOfSubmission();
        }

        private DateTime newDate;
        public DateTime NewDate
        {
            get => newDate;
            set
            {
                if (SetProperty(ref newDate, value))
                {
                    UpdateTimeOfSubmission();
                }
            }
        }

        private TimeSpan newTime;
        public TimeSpan NewTime
        {
            get => newTime;
            set
            {
                if (SetProperty(ref newTime, value))
                {
                    UpdateTimeOfSubmission();
                }
            }
        }

        private void UpdateTimeOfSubmission()
        {
            // Combines the date and time selected by the user
            NewTimeOfSubmission = NewDate.Add(NewTime);
        }

        [RelayCommand]
        public async Task BookOrder()
        {
            try
            {
                var order = new Order
                {
                    CustomerName = NewCustomerName,
                    CustomerAddress = NewCustomerAddress,
                    CarBrand = NewCarBrand,
                    CarModel = NewCarModel,
                    RegistrationNumber = NewRegNumber,
                    TimeOfSubmission = NewTimeOfSubmission,
                    Reperation = NewReperation
                };

                var status = await _database.SaveNewOrder(order);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception saving new order: " + ex.Message);
            }
        }
    }
}
