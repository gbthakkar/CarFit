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

        //ctor
        public CleaningListViewModel()
        {
            _carWashService = App.IoCContainer.Resolve<ICarWashService>();
            ShowCalenderCommand = new DelegateCommand(ShowCalender);
            PageTapCommand = new DelegateCommand(PageTapAction);
            LoadCleaningList();
        }


        private ICarWashService _carWashService;
        public new event PropertyChangedEventHandler PropertyChanged;

        DateTime _fromDate = new DateTime(2020,5,21);
        public DateTime FromDate
        {
            get { return _fromDate;}
            set
            {
                _fromDate = value;
                //OnPropertyChanged(nameof(FromDate));
                OnPropertyChanged(nameof(FilterDate));
                LoadCleaningList();
            }
        
        }
        
        DateTime _toDate = new DateTime(2020, 5, 21);

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


                //at present using only one date, so 
                tmp = $"{FromDate:dd-MMM-yy}";


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

        


       

        public void LoadCleaningList()
        {
            //var source = _carWashService.GetCleaningList();
            this.CleaningList = new ObservableCollection<CarWashTask>(_carWashService.GetCleaningList(FromDate));
            //return source;
            OnPropertyChanged(nameof(CleaningList));

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
