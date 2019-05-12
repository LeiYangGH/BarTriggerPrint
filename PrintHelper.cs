using RawPrint;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZplLabels.ZPL;

namespace BarTriggerPrint
{
    public static class PrintHelper
    {
        public static string GenerateBarcodeZpl(string barcode)
        {
            ZplLabel lbl = new ZplLabel();
            var label = lbl.Load(
                ZplFactory.TextField().At(1, 150)
                .SetFont(Fonts.D, FieldOrientation.Normal, 84)
                .WithData("PO Number").Centered(1200).Underline(),
                ZplFactory.BarcodeField().At(1, 250)
                .SetBarcodeType(BarcodeType.Code128)
                .SetFont(Fonts.D, FieldOrientation.Normal, 48)
                .WithData(barcode).Height(150).BarWidth(4).Centered(1200)
                ).At(1, 50);
            string zpl = label.ToString();
            Log.Instance.Logger.Info($"生成了zpl:{zpl}");

            return zpl;

        }


        public static string GenerateLabelZplByTempate(string barcode, string templateZplFile)
        {
            string templateContent = File.ReadAllText(templateZplFile, Encoding.UTF8);
            string replacedZpl = templateContent.Replace(Constants.BarcodeToBeReplaced, barcode);
            Log.Instance.Logger.Info($"从模板{templateZplFile}替换了条码{barcode}。");
            return replacedZpl;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static void RawPrintZplString(string zpl)
        {
            try
            {
                PrinterSettings settings = new PrinterSettings();
                string defaultPrinter = settings.PrinterName;
                Printer printer = new Printer();

                //Console.WriteLine(settings.PrinterName);
                Log.Instance.Logger.Info($"默认打印机是{defaultPrinter}");
                using (var stream = GenerateStreamFromString(zpl))
                {
                    printer.PrintRawStream(defaultPrinter, stream, "BarTriggerPrint打印", false);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error(ex.Message);
            }

        }

    }
}
