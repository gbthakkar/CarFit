using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarFit.Models;
using CarFit.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarFit.ViewModels;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using SkiaSharp;
using XamForms.Controls;
using DryIoc;

namespace CarFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningList : ContentPage
    {

        #region Fields

        //private ICleaningListViewModel _cleaningListViewModel;
        private IDialogService _dialogService;
        private List<TaskStatusMap> _TaskStatusMap;
        #endregion

        #region Constructor 

        public CleaningList()
        {
            InitializeComponent();

            //_cleaningListViewModel = cleaningListViewModel;
            _dialogService = App.IoCContainer.Resolve<IDialogService>();
            ICommonService commonService = App.IoCContainer.Resolve<ICommonService>();
            _TaskStatusMap = commonService.GetTaskMapList();

            //this.BindingContext = _cleaningListViewModel;

            //TapGestureRecognizer objTapGestureRecognizer1 = new TapGestureRecognizer();
            //objTapGestureRecognizer1.Tapped += ((o2, e2) =>
            //{
            //    _cleaningListViewModel.IsCalenderVisible = false;
            //});
            //this.Content.GestureRecognizers.Add(objTapGestureRecognizer1);


        }
        #endregion


        #region Properties
        #endregion


        #region Methods

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state = Common.Util.GetWidthState(width);

            VisualStateManager.GoToState(PageHeading, state);
        }
        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var obj = this.BindingContext as CleaningListViewModel;
            if (obj.IsCalenderVisible)
            {
                obj.IsCalenderVisible = false;
            }
        }
        private void Calendar_OnDateClicked(object sender, DateTimeEventArgs e)
        {
            var obj = this.BindingContext as CleaningListViewModel;
            obj.FromDate = e.DateTime;

        }
        #endregion









    }
}