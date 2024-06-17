using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
		BindingContext = new NewPageViewModel();
    }
}