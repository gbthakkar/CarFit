using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using CarFit.Models;
using CarFit.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;
using Xamarin.Forms;
using DryIoc;

namespace CarFit.ViewModels
{


    public class CleaningListViewModel : BindableBase, INotifyPropertyChanged, ICleaningListViewModel
    {

        #region Fields

        private readonly ICarWashService _carWashService; //for getting data from API
        private readonly ICommonService _commonService; // for getting master data from API
        private bool _isRefreshing; //flag to track refresh
        private Command _refreshViewCommand; //command to trigger refresh.
        DateTime _fromDate = new DateTime(2020, 5, 21);//use to filter data while fetching from API
        DateTime _toDate = new DateTime(2020, 5, 21);//use to filter data while fetching from API in case of we implement date range.
        private bool _isCalenderVisible = false;//flage to control calendar visibility
        private List<TaskStatus> _taskStatuses;//to hold all task statuses.


        #endregion Fields


        #region Constructor
        public CleaningListViewModel()
        {
            _carWashService = App.IoCContainer.Resolve<ICarWashService>();
            _commonService = App.IoCContainer.Resolve<ICommonService>();
            ShowCalenderCommand = new DelegateCommand(ShowCalender);
            PageTapCommand = new DelegateCommand(PageTapAction);
        }

        #endregion
        //ctor

        #region Properties

        public new event PropertyChangedEventHandler PropertyChanged;// to invoke property change event.
        public DateTime FromDate //getter setter for _fromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged(nameof(FromDate));
                OnPropertyChanged(nameof(FilterDate));
                LoadCleaningList();
            }

        }
        public DateTime ToDate//getter setter for _toDate.
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                //OnPropertyChanged(nameof(ToDate));
                OnPropertyChanged(nameof(FilterDate));
            }

        }
        public string FilterDate // formatted date to display on label.
        {
            get
            {
                string tmp = "";

                if ((FromDate, ToDate) == (System.DateTime.Today, DateTime.Today))
                {
                    tmp = "Today";
                }
                else
                {
                    tmp = $"{FromDate:dd-MMM} to {ToDate:dd-MMM}";
                }


                //at present using only one date, so 
                tmp = $"{FromDate:dd-MMM-yyyy}";


                return tmp;
            }

        }
        public ICommand ShowCalenderCommand { get; private set; }//to invoke command/method to change flag to display calendar
        public ICommand PageTapCommand { get; private set; }//to invoke command/method to change flag to hide calendar

        public ObservableCollection<CarWashTask> CleaningList { get; private set; }//cleaning task list data.

        public bool IsCalenderVisible //getter setter for _isCalendarVisible flag.
        {
            get { return _isCalenderVisible; }
            set
            {
                _isCalenderVisible = value;
                OnPropertyChanged(nameof(IsCalenderVisible));
            }
        }

        public List<TaskStatus> TaskStatusList//getter property for _taskStatuses.
        {
            get { return _taskStatuses; }
        }

        public bool IsRefreshing //getter setter for _isRefreshing flag.
        {
            get => _isRefreshing;
            //set => SetProperty(ref _isRefreshing, value);
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        #endregion Properties


        #region Methods

        public void LoadCleaningList()//fetch data from API
        {
            //var source = _carWashService.GetCleaningList();
            this.CleaningList = new ObservableCollection<CarWashTask>(_carWashService.GetCleaningList(FromDate));
            //return source;
            OnPropertyChanged(nameof(CleaningList));

        }

        private void ShowCalender()//command delegate  to change the flag.
        {
            this.IsCalenderVisible = true;
        }

        private void PageTapAction()//command delegate  to change the flag.
        {
            this.IsCalenderVisible = false;
        }

        //to call each time when property value get change
        protected new virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command RefreshViewCommand //command to fresh data.
        {
            get
            {
                return _refreshViewCommand ?? (_refreshViewCommand = new Command(() =>
                {
                    this.RefreshData();
                }));
            }
        }

        private void RefreshData()//method to each time load data [first time or onRefresh.]
        {
            _taskStatuses = _commonService.GetTaskStatusList();
            LoadCleaningList();
            this.IsRefreshing = false;
        }

        #endregion Methods







    }
}
