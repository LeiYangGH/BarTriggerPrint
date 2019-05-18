using Seagull.BarTender.Print;
using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BarTriggerPrint.Converters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class BtwFile2ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (!LabelOperator.isObjectExistingFile(value))
                return null;
            string btwFileName = (string)value;
            try
            {
                System.Drawing.Image btwImage =
                    LabelFormatThumbnail.Create(btwFileName, System.Drawing.Color.Gray, 500, 500);
                using (var ms = new MemoryStream())
                {
                    btwImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;

                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = ms;
                    bi.EndInit();
                    btwImage.Dispose(); //if bmp is not used further.
                    return bi;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error($"获取缩略图错误:{ex.Message}");
                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

