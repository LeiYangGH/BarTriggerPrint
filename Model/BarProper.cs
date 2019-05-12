using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public abstract class BarProper
    {

        protected int serialNumber;

        public BarProper()
        {
            this.serialNumber = 0;
        }

        public virtual string GetNewSerialNumberString()
        {
            string sn = this.serialNumber.ToString().PadLeft(5, '0');
            this.serialNumber++;
            return sn;
        }
    }
}
