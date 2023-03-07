using System;
using Windows.UI.Xaml.Data;

namespace AccountingApp.Tools
{
    internal class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof(bool))
                return (bool)value;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}