using BarTriggerPrint.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
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
            this.CurrentBarcode = "";
        }


        private string currentBarcode;
        public string CurrentBarcode
        {
            get
            {
                return this.currentBarcode;
            }
            protected set
            {
                if (this.currentBarcode != value)
                {
                    this.currentBarcode = value;
                    this.RaisePropertyChanged(nameof(CurrentBarcode));
                }
            }
        }


        public string Name { get; protected set; }
        public bool IsSelected { get; set; }
        public BarProper BarProper { get; protected set; }


        public string GetZplTemplateFile()
        {
            return Path.Combine(Constants.ZplTemplatesDir, this.Name + ".prn");
        }

        public abstract string GenerateBarcode();
    }

}
