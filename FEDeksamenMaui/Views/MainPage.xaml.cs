using FEDeksamenMaui.ViewModels;

namespace FEDeksamenMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }

}
