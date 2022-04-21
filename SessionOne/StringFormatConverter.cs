using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SessionOne
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "R")
                return "Racer";
            else if ((string)value == "C")
                return "Coordinator";
            else if ((string)value == "A")
                return "Admin";
            else
                return new BitmapImage(new Uri("C:\\Users\\sitka\\source\\repos\\Session\\SessionOne\\SessionOne\\Images\\Charity\\" + value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
