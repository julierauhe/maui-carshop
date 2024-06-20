using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui.Views;

public partial class InvoicePage : ContentPage
{
	public InvoicePage()
	{
		InitializeComponent();

        var database = App.Services.GetService<IDatabase>();
        BindingContext = new InvoiceViewModel(database);
    }
}