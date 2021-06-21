using System;

namespace Muh.Models
{
    public static class StringToDate
    {
        public static DateTime Date(string dat)
        {
            string cday = dat.Substring(0, 2);

            string cmonth = dat.Substring(3, 2);
            string cyear = dat.Substring(6, 4);

            int day = Convert.ToInt32(cday);
            int month = Convert.ToInt32(cmonth);
            int year = Convert.ToInt32(cyear);

            return new DateTime(year, month, day);
        }

        internal static string Date(DateTime bDat)
        {
            throw new NotImplementedException();
        }
    }

    public static class DateToString
    {
        public static string CDat(DateTime? Dt)
        {
            if (Dt == null)
                return "";

            DateTime dDat = (DateTime)Dt;
            string dat = dDat.ToString("dd.MM.yyyy");
            string cday = dat.Substring(0, 2);
            string cmonth = dat.Substring(3, 2);
            string cyear = dat.Substring(6, 4);
            return cday + "." + cmonth + "." + cyear;
        }
    }
}
