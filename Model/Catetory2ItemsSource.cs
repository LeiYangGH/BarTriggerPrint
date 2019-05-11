using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BarTriggerPrint.Model
{
    public class Catetory2ItemsSource : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection collection = new ItemCollection();
            collection.Add("X");
            collection.Add("YY");
            collection.Add("ZZZ");
            return collection;
        }
    }
}
