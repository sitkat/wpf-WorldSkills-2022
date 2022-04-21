using System;
using System.Globalization;
using System.Windows.Data;

namespace SessionOne
{
    class Helper
    {
        public string CountTimeToEvent()
        {
            DateTime otherDate = new DateTime(2022, 6, 20, 20, 0, 0);
            TimeSpan remaining = otherDate - DateTime.Now;
            DateTime total = new DateTime() + remaining;
            return "До начала события осталось " + total.Year + " лет, " + total.Month + " месяцев, " + total.Day + " дней, " + total.Hour + " часов, " + total.Minute + " минут " + total.Second + " и секунд.";
        }
    }
    public static class SaveThings
    {
        public static string? charName;
        public static string? racerName;
        public static string? payment;
        public static string? email;
        public static string? NameCharity;
        public static string? EditEmail;
    }
}