using BarTriggerPrint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    public class Barcode1GeneratorViewModel : BarcodeGeneratorViewModel
    {
        public Barcode1GeneratorViewModel()
        {
            this.Name = Constants.ProductName1;
            this.BarProper = new BarProper1();
        }

        public override string GenerateBarcode()
        {
            var p = this.BarProper as BarProper1;
            StringBuilder sb = new StringBuilder();
            sb.Append(p.CustomerNumber.Trim());
            sb.Append("#");
            sb.Append(p.SupplierNumber.Trim());
            sb.Append("#");
            sb.Append(p.ProductDate.ToString("yyMMdd").Trim());
            sb.Append("#");
            sb.Append(p.GetNewSerialNumberString());
            this.CurrentBarcode = sb.ToString();
            return this.CurrentBarcode;
        }
    }
}
