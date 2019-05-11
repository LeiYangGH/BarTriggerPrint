using BarTriggerPrint.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    public class BarcodeGeneratorViewModel : ViewModelBase
    {

        public BarcodeGeneratorViewModel()
        {
            this.BarProper = new BarProper();
        }
        public BarProper BarProper { get; set; }
    }

}
