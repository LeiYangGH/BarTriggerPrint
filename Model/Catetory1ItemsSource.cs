using System;
using System.Collections.Generic;
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
            collection.Add("A");
            collection.Add("BB");
            collection.Add("CCC");
            return collection;
        }
    }
}
