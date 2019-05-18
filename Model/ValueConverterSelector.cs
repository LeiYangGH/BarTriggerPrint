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
            FieldsValueConverter fieldsValueConverter2Create = new SimpleConverter("yyMMdd", 4);
            if (templateDir.Contains("066"))
            {
                fieldsValueConverter2Create = new No066Converter();
            }
            else if (templateDir.Contains("340"))
            {
                fieldsValueConverter2Create = new SimpleConverter("dd-MM-yy", 7);
            }
            else if (templateDir.Contains("460"))
            {
                fieldsValueConverter2Create = new No460Converter();
            }
            else if (templateDir.Contains("463")
                || templateDir.Contains("467"))
            {
                fieldsValueConverter2Create = new No463Converter();
            }
            else if (templateDir.Contains("465"))
            {
                fieldsValueConverter2Create = new No465Converter();
            }
            else if (templateDir.Contains("466"))
            {
                fieldsValueConverter2Create = new No466Converter();
            }
            existingFieldsValueConvertersDict.Add(templateDir, fieldsValueConverter2Create);
            return fieldsValueConverter2Create;
        }
    }
}
