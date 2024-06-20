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

    private void OnDateSelected(object sender, SelectionChangedEventArgs e)
    {
        //if (e.CurrentSelection.FirstOrDefault() is DayViewModel selectedDay)
        //{
        //    var viewModel = (CalendarViewModel)BindingContext;
        //    viewModel.SelectedDay = selectedDay;
        //}
    }
}