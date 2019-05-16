using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint
{
    public class LabelOperator
    {
        private Engine engine = null;
        private Dictionary<string, LabelFormatDocument> fileLableDict =
    new Dictionary<string, LabelFormatDocument>();

        public LabelOperator(Engine engine)
        {
            this.engine = engine;
        }
        public LabelFormatDocument OpenLabel(string file)
        {
            if (file != null && File.Exists(file))
            {
                LabelFormatDocument label = null;

                if (this.fileLableDict.ContainsKey(file))
                    label = this.fileLableDict[file];
                else
                {
                    try
                    {
                        label = this.engine.Documents.Open(file);
                        this.fileLableDict.Add(file, label);
                    }
                    catch (Exception ex)
                    {
                        Log.Instance.Logger.Error($"打开btw标签出错{ex.Message}");
                    }

                }

                return label;
            }
            else
                return null;
        }


        public string[] GetLabelFields(string file)
        {
            LabelFormatDocument label = this.OpenLabel(file);
            if (label != null)
            {
                return label.SubStrings.OfType<SubString>().Select(x => x.Name.Trim()).ToArray();
            }
            else
                return new string[] { };
        }


        public bool IsFieldInLabelFile(string checkField, string file)
        {
            string[] fieldsIn = this.GetLabelFields(file);
            return fieldsIn.Contains(checkField) ||
                Constants.FieldsAliasDict[checkField].Any(a => fieldsIn.Contains(a));
        }
    }
}
