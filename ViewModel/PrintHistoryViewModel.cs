using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    public class PrintHistoryViewModel : ViewModelBase
    {
        public PrintHistoryViewModel(string btwTemplate, string barcode, string printDate)
        {
            this.BtwTemplate = btwTemplate;
            this.Barcode = barcode;
            this.PrintDate = printDate;
        }
        public string BtwTemplate { get; set; }
        public string Barcode { get; set; }
        public string PrintDate { get; set; }
    }
}
