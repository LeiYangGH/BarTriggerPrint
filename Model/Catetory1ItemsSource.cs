using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BarTriggerPrint.Model
{

    public class Catetory1ItemsSource : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection collection = new ItemCollection();
            foreach (DataRow dr in BarProper1.dt.Rows)
            {
                string s = dr[0].ToString().Trim();
                collection.Add(s);
            }
            return collection;
        }



    }
}
