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
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Models.Order> Model1Items { get; set; } = new();

        [ObservableProperty]
        private Models.Order? _selectedItem;

        public string NewCustomerName { get; set; }
        public string NewCustomerAddress { get; set; }
        public string NewCarBrand { get; set; }
        public string NewCarModel { get; set; }
        public string NewRegNumber { get; set; }
        public DateTime NewTimeOfSubmission { get; set; }
        public string NewReperation { get; set; }


        private readonly IDatabase _database;

        private DateOnly newDate;
        public DateOnly NewDate
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

        private TimeOnly newTime;
        public TimeOnly NewTime
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
            NewTimeOfSubmission = new DateTime(NewDate.Year, NewDate.Month, NewDate.Day, NewTime.Hour, NewTime.Minute, NewTime.Second);
        }

        public MainViewModel(IDatabase database)
        {
            _database = database;
            Initialize();
        }

        private async Task Initialize()
        {
            NewDate = DateOnly.FromDateTime(DateTime.Now);
            NewTime = TimeOnly.FromDateTime(DateTime.Now);
            UpdateTimeOfSubmission();
        }

        [RelayCommand]
        public async Task ShowCalendar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CalendarPage());
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
