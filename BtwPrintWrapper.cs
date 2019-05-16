using Seagull.BarTender.Print;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace BarTriggerPrint
{
    public class BtwPrintWrapper
    {

        public static string PrintBtwFile(LabelFormatDocument updatedFormat, Engine btEngine)
        {

            Messages messages;
            int waitForCompletionTimeout = 10000;
            Result result = updatedFormat.Print("在线打印系统测试打印", waitForCompletionTimeout, out messages);
            string messageString = "\n\nMessages:";
            foreach (Seagull.BarTender.Print.Message message in messages)
            {
                messageString += "\n\n" + message.Text;
            }
            return messageString;
        }

        public static void PrintPreviewLabel2File(
            LabelFormatDocument updatedFormat, Engine btEngine)
        {
            try
            {
                Messages msgs;
                Resolution r = new Resolution(200);
                if (!Directory.Exists(Constants.previewDir))
                    Directory.CreateDirectory(Constants.previewDir);
                updatedFormat.ExportPrintPreviewToFile(Constants.previewDir,
                    "当前打印预览.bmp", ImageType.BMP, ColorDepth.ColorDepth16, r,
                    System.Drawing.Color.White, OverwriteOptions.DoNotOverwrite,
                    false, false, out msgs);
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Info($"导出预览错误:{ex.Message}");
            }

        }
    }
}
