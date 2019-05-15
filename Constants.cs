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
        public const string ProductName1 = "众泰滑柱";
        public const string ProductName2 = "产品2";
        public static readonly string btwTopDir = Path.Combine(AppDataBarTriggerPrintDir, "打印模板");
        public static readonly string FieldsAliasXmlFile = 
            Path.Combine(btwTopDir, "字段别名.xml");
        public static readonly Dictionary<int, string> ShiftsIntStrDict =
            new Dictionary<int, string>()
            {
                { 1, "早班" },
                { 2, "中班" },
                { 3, "晚班" }
            };

        public static readonly Dictionary<string, string[]> FieldsAliasDict =
            new Dictionary<string, string[]>();
    }
}
