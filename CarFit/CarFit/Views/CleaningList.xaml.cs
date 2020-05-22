using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CarFit.ViewModels;
using Prism.Services.Dialogs;

namespace CarFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningList : ContentPage
    {
        public CleaningList()
        {
            InitializeComponent();
            // BindingContext = new CleaningListViewModel(dialogService);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state = Common.Util.GetWidthState(width);

            VisualStateManager.GoToState(PageHeading, state);
        }


    }
}