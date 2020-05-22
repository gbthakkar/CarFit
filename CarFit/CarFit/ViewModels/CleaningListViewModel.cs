using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using CarFit.Models;
using CarFit.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;

namespace CarFit.ViewModels
{
    public class CleaningListViewModel : BindableBase, INotifyPropertyChanged
    {
        private ICarWashService _carWashService;

        public DateTime FromDate { get; set; } = DateTime.Today;
        public DateTime ToDate { get; set; } = DateTime.Today;


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


        public ObservableCollection<CarWashTask> CleaningList { get; private set; }

        public CleaningListViewModel(IDialogService dialogService, INavigationService navigationService
        , ICarWashService carWashService
        )
        {
            _carWashService = carWashService;


            //source = new List<CarWashTask>();
            GetCleaningList();
        }

        void GetCleaningList()
        {
            //source = _carWashService.GetCleaningList();
            this.CleaningList = new ObservableCollection<CarWashTask>(_carWashService.GetCleaningList());
        }
    }
}
