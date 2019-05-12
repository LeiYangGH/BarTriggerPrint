using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BarTriggerPrint.Model
{
    [CategoryOrder("可选值", 1)]
    [CategoryOrder("匹配值", 2)]
    [CategoryOrder("变化值", 3)]
    [DisplayName("请选择条码组成")]
    public class BarProper1 : BarProper
    {
        public static DataTable dt;

        private int startNumber;

        public BarProper1()
        {
            this.CustomerNumber = "";
            this.SupplierNumber = "";
            this.ProductDate = DateTime.Now;
            if (BarProper1.dt == null)
                BarProper1.dt = this.ReadExcel(Path.Combine(Constants.AppDataBarTriggerPrintDir,
                    "众泰滑柱字段关联.xlsx")).Tables[0];
        }

        private string labelType;
        [PropertyOrder(1)]
        [Category("可选值")]
        [ItemsSource(typeof(Catetory1ItemsSource))]
        [DisplayName("标签种类")]
        public string LabelType
        {
            get
            {
                return this.labelType;
            }
            set
            {
                if (value != this.labelType)
                {
                    this.labelType = value;
                    DataRow dr = dt.Rows.OfType<DataRow>()
                        .First(r => r[0].ToString() == value.Trim());
                    this.CustomerNumber = dr[1].ToString().Trim();
                    this.OnPropertyChanged(nameof(CustomerNumber));
                    this.SupplierNumber = dr[2].ToString().Trim();
                    this.OnPropertyChanged(nameof(SupplierNumber));

                }

            }
        }

        [PropertyOrder(2)]
        [Category("匹配值")]
        [DisplayName("顾客零件号")]
        public string CustomerNumber { get; set; }

        [PropertyOrder(3)]
        [Category("匹配值")]
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

        private DataSet ReadExcel(string excelFile)
        {
            using (var stream = File.Open(excelFile, FileMode.Open, FileAccess.Read))
            {
                var reader = ExcelReaderFactory.CreateReader(stream, this.excelReaderConfiguration);
                var result = reader.AsDataSet(this.excelDataSetConfiguration);
                return result;
            }
        }

    }
}
