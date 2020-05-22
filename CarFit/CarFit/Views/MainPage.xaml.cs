using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarFit.Views
{
    public partial class MainPage : ContentPage
    {
        private Views.ICleaningList _cleaningListPage;


        public MainPage(Views.ICleaningList cleaningListPage)
        {
            InitializeComponent();
            _cleaningListPage = cleaningListPage;
        }

        private async void BtnCleaningList_Clicked(object sender, EventArgs e)
        {
            var pg = _cleaningListPage as Views.CleaningList;
            await Navigation.PushAsync(pg);
        }

        //private async void btnCalendar_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Calendar());
        //}

    }
}