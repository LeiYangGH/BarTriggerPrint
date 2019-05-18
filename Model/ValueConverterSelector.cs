using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public static class ValueConverterSelector
    {
        private static readonly Dictionary<string, FieldsValueConverter> existingFieldsValueConvertersDict =
            new Dictionary<string, FieldsValueConverter>();
        public static FieldsValueConverter SelectByTemplateDir(string templateDir)
        {
            if (existingFieldsValueConvertersDict.ContainsKey(templateDir))
                return existingFieldsValueConvertersDict[templateDir];
            FieldsValueConverter fieldsValueConverter2Create = new SimpleConverter();
            if (templateDir.Contains("066"))
            {
                fieldsValueConverter2Create = new No066Converter();
            }
            existingFieldsValueConvertersDict.Add(templateDir, fieldsValueConverter2Create);
            return fieldsValueConverter2Create;
        }
    }
}
