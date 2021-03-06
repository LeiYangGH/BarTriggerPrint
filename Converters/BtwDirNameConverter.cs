﻿using System;
using System.IO;
using System.Windows.Data;

namespace BarTriggerPrint.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class BtwDirNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return Path.GetFileNameWithoutExtension((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
