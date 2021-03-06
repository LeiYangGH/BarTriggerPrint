﻿using System;
using System.IO;
using System.Windows.Data;

namespace BarTriggerPrint.Converters
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class SelectedBtw2PrintEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return LabelOperator.isObjectExistingFile(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
