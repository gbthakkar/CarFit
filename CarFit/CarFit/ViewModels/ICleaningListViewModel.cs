using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CarFit.Models;

namespace CarFit.ViewModels
{
    public interface ICleaningListViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        string FilterDate { get; }
        //ICommand ShowCalenderCommand { get; }
        ObservableCollection<CarWashTask> CleaningList { get; }
        bool IsCalenderVisible { get; set; }
        void LoadCleaningList();

        List<TaskStatus> TaskStatusList { get; }
    }
}
