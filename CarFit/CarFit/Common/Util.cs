using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarFit.Common
{
    public class Util
    {
        public static string GetWidthState(double width)
        {
            string state = "Small";
            int wd = Convert.ToInt32(width);
            //TODO: review width parameter for state.
            state= wd < 280 ? "Small" : wd == 320 ? "Small" : wd < 380 ? "Medium" : "Large";
            //state= wd < 280 ? "Small" : wd < 360 ? "Medium" : "Large";
            return state;
        }
    }


   
}
