using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui.Views;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
	{
		InitializeComponent();

        var database = App.Services.GetService<IDatabase>();
        BindingContext = new NewPageViewModel(database);
    }
}