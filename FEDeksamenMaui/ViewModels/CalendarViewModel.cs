using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using FEDeksamenMaui.Models;
using FEDeksamenMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        private DateTime _currentDate;
        public ObservableCollection<Order> OrdersForSelectedDate { get; set; } = new();
        public ObservableCollection<DayViewModel> Days { get; set; } = new();
        
        [ObservableProperty]
        private DayViewModel? _selectedDate;

        [ObservableProperty]
        private string monthYear;

        [ObservableProperty]
        private bool errorMessageVisible;

        [ObservableProperty]
        private string calendarErrorMessage;

        [ObservableProperty]
        private Order? selectedOrder;

        private readonly IDatabase _database;

        public CalendarViewModel(IDatabase database)
        {
            _database = database;
            _ = Initialize();
        }

        private async Task Initialize()
        {
            _currentDate = new DateTime(2024, 6, 1);
            UpdateCalendar();
        }

        [RelayCommand]
        public async Task CreateInvoice()
        {
            if(_selectedDate == null)
            {
                CalendarErrorMessage = "Please choose a date";
                ErrorMessageVisible = true;
            }
            else if(selectedOrder == null)
            {
                CalendarErrorMessage = "Please choose an order";
                ErrorMessageVisible = true;
            }
            else
            {
                ErrorMessageVisible = false;
                await Application.Current.MainPage.Navigation.PushAsync(new InvoicePage(selectedOrder.Id));

            }
        }

        private void UpdateCalendar()
        {
            Days.Clear();
            MonthYear = _currentDate.ToString("MMMM yyyy", CultureInfo.InvariantCulture);

            var daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
            for (int day = 1; day <= daysInMonth; day++)
            {
                var date = new DateTime(_currentDate.Year, _currentDate.Month, day);
                Days.Add(new DayViewModel
                {
                    Date = date,
                    BackgroundColor = "LightGray"
                });
            }
        }

        partial void OnSelectedDateChanged(DayViewModel? oldValue, DayViewModel? newValue)
        {
            if (oldValue != null)
            {
                oldValue.BackgroundColor = "LightGray";
            }

            if (newValue != null)
            {
                newValue.BackgroundColor = "LightBlue";
            }
        }

        [RelayCommand]
        public async Task ShowOrders()
        {
            try
            {
                if (SelectedDate != null)
                {
                    var dateOnly = DateOnly.FromDateTime(SelectedDate.Date);
                    var orders = await _database.GetOrdersForSelectedDate(dateOnly);

                    OrdersForSelectedDate.Clear();
                    foreach (var order in orders)
                    {
                        OrdersForSelectedDate.Add(order);
                    }

                    await Task.CompletedTask;

                    if(orders.Count == 0)
                    {
                        CalendarErrorMessage = "No orders on the selected date";
                        ErrorMessageVisible = true;
                    }
                    else
                    {
                        ErrorMessageVisible = false;
                    }    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exp while showing orders for date: " + ex.Message);
            }
    
        }
    }

    public class DayViewModel : ObservableObject
    {
        public DateTime Date { get; set; }

        public string Day => Date.Day.ToString();

        private string _backgroundColor;
        public string BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                SetProperty(ref _backgroundColor, value);
            }
        }
    }
}
