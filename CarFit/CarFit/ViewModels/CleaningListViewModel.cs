using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using CarFit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;

namespace CarFit.ViewModels
{
    public class CleaningListViewModel : BindableBase, INotifyPropertyChanged
    {
        readonly IList<CarFit.Models.CarWashTask> source;

        public ObservableCollection<CarWashTask> CleaningList { get; private set; }

        public CleaningListViewModel(IDialogService dialogService, INavigationService navigationService)
        {
            source = new List<CarWashTask>();
            CreateMonkeyCollection();
        }

        void CreateMonkeyCollection()
        {
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Jeff Peterson",
                WashType = "Wash medium, Clean inside",
                TaskStatus = new TaskStatus(){Name = "Done",Color = "#25A87B" },
                StartTimeUtc=new DateTime(2020,05,21,8,0,0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 2",
                WashType = "Wash medium, Wash inside",
                TaskStatus = new TaskStatus() { Name = "InProgress", Color = "#F5C7O9" },
                ExpectedStartTimeUtc = new DateTime(2020, 05, 21, 8, 0, 0),
                ExpectedEndTimeUtc = new DateTime(2020, 05, 21, 10, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 3",
                WashType = "Wash Type - 3",
                TaskStatus = new TaskStatus() { Name = "ToDo", Color = "#4E77D6" },
                StartTimeUtc = new DateTime(2020, 05, 21, 10, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 4",
                WashType = "Wash Type - 4",
                TaskStatus = new TaskStatus() { Name = "ToDo", Color = "#4E77D6" },
                StartTimeUtc = new DateTime(2020, 05, 21, 12, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 5",
                WashType = "Wash Type - 5",
                TaskStatus = new TaskStatus() { Name = "ToDo", Color = "#4E77D6" },
                StartTimeUtc = new DateTime(2020, 05, 21, 14, 0, 0)
            });



            this.CleaningList = new ObservableCollection<CarWashTask>(source);
        }
    }
}
