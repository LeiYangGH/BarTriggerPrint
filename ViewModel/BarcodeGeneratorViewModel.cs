using BarTriggerPrint.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    public abstract class BarcodeGeneratorViewModel : ViewModelBase
    {

        public BarcodeGeneratorViewModel()
        {
            //this.BarProper = new BarProper1();
        }

        public string Name { get; protected set; }
        public bool IsSelected { get; set; }
        public BarProper BarProper { get; protected set; }
    }

}
