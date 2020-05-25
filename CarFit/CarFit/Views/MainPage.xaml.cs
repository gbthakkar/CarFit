using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFit.ViewModels;
using DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace CarFit.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            //var abc = containerRegistry.GetContainer().Resolve<ICleaningListViewModel>();
            //var abc = App.IoCContainer.Resolve<ICleaningListViewModel>();
        }

        private async void BtnCleaningList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CleaningList());
        }

        //private async void btnCalendar_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Calendar());
        //}

    }
}