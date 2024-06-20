using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var database = App.Services.GetService<IDatabase>();
            BindingContext = new MainViewModel(database);
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
}
