using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        [RelayCommand]
        public async Task OnCounterClicked()
        {
            //implement what happens when command is 'activated'
        }
    }
}
