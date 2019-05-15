using Seagull.BarTender.Print;
using System;
using System.Linq;
using System.Windows;

namespace BarTriggerPrint
{
    public class BtwPrintWrapper
    {

        public static string PrintBtwFile(string btwFile, Engine btEngine)
        {

            Messages messages;
            LabelFormatDocument format = btEngine.Documents.Open(btwFile);
            Console.WriteLine(string.Join(" ", format.SubStrings
                .OfType<SubString>().Select(x=>x.Name)));
            int waitForCompletionTimeout = 10000; // 10 seconds
            format.SubStrings["序列号"].Value = "xxxxyyyy";
            //format.SubStrings["序列号111"].Value = "xxxxyyyy";

            Result result = format.Print("测试打印" + System.IO.Path.GetFileName(btwFile), waitForCompletionTimeout, out messages);
            string messageString = "\n\nMessages:";
            foreach (Seagull.BarTender.Print.Message message in messages)
            {
                messageString += "\n\n" + message.Text;
            }

            return messageString;

        }
    }
}
