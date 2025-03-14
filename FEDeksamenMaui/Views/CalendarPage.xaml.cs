using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui.Views;

public partial class CalendarPage : ContentPage
{
    public CalendarPage()
	{
		InitializeComponent();

        var database = App.Services.GetService<IDatabase>();
        BindingContext = new CalendarViewModel(database);
    }

    private async void OnDateSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DayViewModel selectedDate)
        {
            var viewModel = (CalendarViewModel)BindingContext;
            viewModel.SelectedDate = selectedDate;
            await viewModel.ShowOrdersCommand.ExecuteAsync(null);
        }
    }
}