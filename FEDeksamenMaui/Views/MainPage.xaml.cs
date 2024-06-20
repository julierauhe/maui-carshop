using FEDeksamenMaui.Data;
using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var database = App.Services.GetService<IDatabase>();
            BindingContext = new MainViewModel(database);
        }

        private async void OnOrderSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is DayViewModel selectedDate)
            {
                var viewModel = (CalendarViewModel)BindingContext;
                viewModel.SelectedDate = selectedDate;
                await viewModel.ShowOrdersCommand.ExecuteAsync(null);
            }
        }
    }
}
