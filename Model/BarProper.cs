using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    [DisplayName("请选择条码组成")]
    public class BarProper
    {
        [DisplayName("品类")]
        public string Catetory1 { get; set; }

        [DisplayName("子类")]
        public string Catetory2 { get; set; }

        [DisplayName("生产日期")]
        public DateTime ProductDate { get; set; }

        [DisplayName("班次")]
        public string Shift { get; set; }

        [DisplayName("开始流水号")]
        public int StartNumber { get; set; }
    }
}
