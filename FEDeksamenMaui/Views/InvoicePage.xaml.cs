using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui.Views;

public partial class InvoicePage : ContentPage
{
	public InvoicePage(int orderId)
	{
		InitializeComponent();

        var database = App.Services.GetService<IDatabase>();
        BindingContext = new InvoiceViewModel(database, orderId);
    }
}