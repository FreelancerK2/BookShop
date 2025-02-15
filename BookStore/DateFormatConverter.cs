using System;
using System.Globalization;
using System.Windows.Data;

namespace BookStore
{
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return date.ToString("MM/dd/yyyy"); // Change format if needed
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                return date;
            }
            return value;
        }
    }
}
