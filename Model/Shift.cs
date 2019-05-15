using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public class Shift
    {
        public Shift(int value)
        {
            this.ShiftValue = value;
            this.ShiftName = Constants.ShiftsIntStrDict[value];
        }
        public int ShiftValue { get; private set; }
        public string ShiftName { get; private set; }
    }
}
