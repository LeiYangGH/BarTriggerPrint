﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BarTriggerPrint.Model
{
    [DisplayName("请选择条码组成")]
    public class BarProper2 : BarProper
    {
        public BarProper2()
        {
            this.ProductDate = DateTime.Now;
        }

        [DisplayName("生产日期")]
        public DateTime ProductDate { get; set; }


        [DisplayName("开始流水号")]
        public int StartNumber { get; set; }
    }
}