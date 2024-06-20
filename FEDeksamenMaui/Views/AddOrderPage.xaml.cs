using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui.Views;

public partial class AddOrderPage : ContentPage
{
	public AddOrderPage()
	{
		InitializeComponent();

        var database = App.Services.GetService<IDatabase>();
        BindingContext = new AddOrderViewModel(database);
    }

    private void OnDateSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DayViewModel selectedDate)
        {
            var viewModel = (CalendarViewModel)BindingContext;
            viewModel.SelectedDate = selectedDate;
        }
    }
}