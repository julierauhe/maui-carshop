using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FEDeksamenMaui.Data;
using FEDeksamenMaui.Models;
using FEDeksamenMaui.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDatabase _database;

        public ObservableCollection<Order> Orders { get; set; } = new();
        public ObservableCollection<ShowInvoiceModel> Invoices { get; set; } = new();

        [ObservableProperty]
        private Order? selectedOrder;

        [ObservableProperty]
        private bool invoicesVisible;

        public MainViewModel(IDatabase database)
        {
            _database = database;
            _ = Initialize();
        }

        private async Task Initialize()
        {
            InvoicesVisible = false;
            await ShowAllOrders();
        }

        [RelayCommand]
        public async Task CreateOrder()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddOrderPage());
            Debug.WriteLine("CreateOrder command executed");
        }

        [RelayCommand]
        public async Task ShowCalendar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CalendarPage());
        }

        public async Task ShowAllOrders()
        {
            try
            {
                var orders = await _database.GetAllOrders();
                Orders.Clear();
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exp while showing orders" + ex.Message);
            }
        }

        [RelayCommand]
        public async Task ShowInvoices()
        {
            try
            {
                if (SelectedOrder != null)
                {
                    var invoice = await _database.GetInvoiceForOrder(SelectedOrder.Id);
                    Invoices.Clear();

                    if (invoice != null)
                    {
                        var order = await _database.GetOrderById(invoice.OrderId);
                        var invoiceViewModel = new ShowInvoiceModel
                        {
                            MechanicName = invoice.MechanicName,
                            HoursUsed = invoice.HoursUsed,
                            Price = invoice.Price,
                            CustomerName = order.CustomerName,
                            MaterialsUsed = invoice.MaterialsUsed
                        };
                        Invoices.Add(invoiceViewModel);
                    }

                    InvoicesVisible = invoice != null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exp while showing invoice: " + ex.Message);
            }
        }
    }

    public class ShowInvoiceModel : ObservableObject
    {
        public string MechanicName { get; set; }
        public int HoursUsed { get; set; }
        public int Price { get; set; }
        public string CustomerName { get; set; }
        public List<Dictionary<string, int>> MaterialsUsed { get; set; }
    }
}
