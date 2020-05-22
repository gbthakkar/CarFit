using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace CarFit.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
