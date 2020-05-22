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

namespace CarFit.ViewModels
{


    public class CleaningListViewModel : BindableBase, INotifyPropertyChanged, ICleaningListViewModel
    {
        

        private ICarWashService _carWashService;
        public new event PropertyChangedEventHandler PropertyChanged;

        DateTime _fromDate = DateTime.Today;
        public DateTime FromDate
        {
            get { return _fromDate;}
            set
            {
                _fromDate = value;
                //OnPropertyChanged(nameof(FromDate));
                OnPropertyChanged(nameof(FilterDate));
            }
        
        }
        
        DateTime _toDate = DateTime.Today;

        public DateTime ToDate
        {
            get { return _toDate;}
            set
            {
                _toDate = value;
                //OnPropertyChanged(nameof(ToDate));
                OnPropertyChanged(nameof(FilterDate));
            }

        }
        
        
        public string FilterDate
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

                return tmp;
            }

        }
        public ICommand ShowCalenderCommand { get; private set; }
        public ICommand PageTapCommand { get; private set; }

        public ObservableCollection<CarWashTask> CleaningList { get; private set; }

        private bool _isCalenderVisible = false;
        public bool IsCalenderVisible
        {
            get { return _isCalenderVisible;}
            set
            {
                _isCalenderVisible = value;
                OnPropertyChanged(nameof(IsCalenderVisible));
            }
        }

        


        //ctor
        public CleaningListViewModel(IDialogService dialogService, INavigationService navigationService
            , ICarWashService carWashService
        )
        {
            _carWashService = carWashService;
            ShowCalenderCommand = new DelegateCommand(ShowCalender);
            PageTapCommand = new DelegateCommand(PageTapAction);

            LoadCleaningList();
            
        }

        public void LoadCleaningList()
        {
            //var source = _carWashService.GetCleaningList();
            this.CleaningList = new ObservableCollection<CarWashTask>(_carWashService.GetCleaningList());
            //return source;
        }


        private void ShowCalender()
        {
            this.IsCalenderVisible = true;
        }

        private void PageTapAction()
        {
            this.IsCalenderVisible = false;
        }

        protected new virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
