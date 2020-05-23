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
using SkiaSharp;

namespace CarFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningList : ContentPage, ICleaningList
    {
        //private ICleaningListViewModel _cleaningListViewModel;
        private IDialogService _dialogService;


        

        //public CleaningList()
        //{
            
        //}

        public CleaningList(IDialogService dialogService)
        {
            InitializeComponent();

            //_cleaningListViewModel = cleaningListViewModel;
            _dialogService = dialogService;

            //this.BindingContext = _cleaningListViewModel;

            //TapGestureRecognizer objTapGestureRecognizer1 = new TapGestureRecognizer();
            //objTapGestureRecognizer1.Tapped += ((o2, e2) =>
            //{
            //    _cleaningListViewModel.IsCalenderVisible = false;
            //});
            //this.Content.GestureRecognizers.Add(objTapGestureRecognizer1);


        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state = Common.Util.GetWidthState(width);

            VisualStateManager.GoToState(PageHeading, state);
        }


        private void FilterFromDate_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            var obj = this.BindingContext as CleaningListViewModel;
            obj.FromDate = e.NewDate;
        }
    }
}