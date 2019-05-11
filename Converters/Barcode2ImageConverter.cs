using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BarTriggerPrint.Converters
{

    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class Barcode2ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string barcode = (string)value;
            if (string.IsNullOrWhiteSpace(barcode))
                return null;

            Bitmap bmp = ZxingHelper.Generate2(barcode, 300, 150);

            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = ms;
                bi.EndInit();
                bmp.Dispose(); //if bmp is not used further.
                return bi;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
