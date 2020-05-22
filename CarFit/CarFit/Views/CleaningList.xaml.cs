using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CarFit.ViewModels;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace CarFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningList : ContentPage, ICleaningList
    {
        private CleaningListViewModel _cleaningListViewModel;
        



        public CleaningList(CleaningListViewModel cleaningListViewModel)
        {
            InitializeComponent();

            _cleaningListViewModel = cleaningListViewModel;
            this.BindingContext = _cleaningListViewModel;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state = Common.Util.GetWidthState(width);

            VisualStateManager.GoToState(PageHeading, state);
        }
        

    }
}