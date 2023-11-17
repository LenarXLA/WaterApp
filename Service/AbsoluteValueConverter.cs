using System;
using System.Globalization;
using System.Windows.Data;

namespace WaterApp.Service
{
    public class AbsoluteValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return Math.Abs(intValue);
            }
            else if (value is double doubleValue)
            {
                return Math.Abs(doubleValue);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
