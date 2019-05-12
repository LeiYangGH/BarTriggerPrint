using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BarTriggerPrint.Model
{
    [CategoryOrder("固定值", 1)]
    [CategoryOrder("变化值", 2)]
    [DisplayName("请选择条码组成")]
    public class BarProper1 : BarProper
    {
        private int startNumber;

        public BarProper1()
        {
            //this.LabelType = "6K00079-1";
            this.CustomerNumber = "";
            this.SupplierNumber = "";
            this.ProductDate = DateTime.Now;
        }

        //[PropertyOrder(1)]
        //[Category("固定值")]
        //[DisplayName("标签种类")]
        //public string LabelType { get; set; }

        [PropertyOrder(2)]
        [Category("固定值")]
        [DisplayName("顾客零件号")]
        public string CustomerNumber { get; set; }

        [PropertyOrder(3)]
        [Category("固定值")]
        [DisplayName("供应商代码")]
        public string SupplierNumber { get; set; }


        [PropertyOrder(4)]
        [Category("变化值")]
        [DisplayName("生产日期")]
        public DateTime ProductDate { get; set; }

        [Category("变化值")]
        [PropertyOrder(5)]
        [DisplayName("开始流水号")]
        public int StartNumber
        {
            get
            {
                return this.startNumber;
            }
            set
            {
                if (value != this.startNumber)
                {
                    this.startNumber = value;
                    this.serialNumber = value;
                }

            }
        }


        public override string GetNewSerialNumberString()
        {
            string sn = this.serialNumber.ToString().PadLeft(5, '0');
            this.serialNumber = (this.serialNumber + 1) % 100000;
            return sn;
        }
    }
}
