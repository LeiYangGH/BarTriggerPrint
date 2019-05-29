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
            if (templateDir.Contains("6K00032"))
            {
                fieldsValueConverter2Create = new No066Converter();
            }
            else if (templateDir.Contains("6K00073"))
            {
                fieldsValueConverter2Create = new No386Converter();
            }
            else if (templateDir.Contains("6K00061"))
            {
                fieldsValueConverter2Create = new SimpleConverter("dd-MM-yy", 7);
            }
            else if (templateDir.Contains("GT303")
                || templateDir.Contains("RT326"))
            {
                fieldsValueConverter2Create = new No460Converter();
            }
            else if (templateDir.Contains("6K00093")
                || templateDir.Contains("6K00083")
                || templateDir.Contains("6K00084"))
            {
                fieldsValueConverter2Create = new No463Converter();
            }
            else if (templateDir.Contains("6K00035"))
            {
                fieldsValueConverter2Create = new No465Converter();
            }
            else if (templateDir.Contains("6K00079"))
            {
                fieldsValueConverter2Create = new No466Converter();
            }
            existingFieldsValueConvertersDict.Add(templateDir, fieldsValueConverter2Create);
            return fieldsValueConverter2Create;
        }
    }
}
