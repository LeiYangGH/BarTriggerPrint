using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace BarTriggerPrint
{
    public static class Constants
    {
        public const string BarTriggerPrint = "BarTriggerPrint";
        public const string BarcodeToBeReplaced = "BarcodeToBeReplaced";
        public const string ZplTemplates = "ZplTemplates";
        public static readonly string AppDataBarTriggerPrintDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"BarTriggerPrint");
        public static readonly string ZplTemplatesDir = Path.Combine(
    AppDataBarTriggerPrintDir, ZplTemplates);
        public const string ProductName1 = "众泰6K00079-1";
        public const string ProductName2 = "产品2";


    }
}
