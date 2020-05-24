using System;
using System.Collections.Generic;
using System.Text;

namespace CarFit.SharedLib
{
    public static class ExtMethods
    {
        public static int ToInt(this Enum pItem)
        {
            int temp = 0;
            try
            {
                temp = Convert.ToInt32(pItem);
            }
            catch
            {

            }
            return temp;
        }
    }
}
