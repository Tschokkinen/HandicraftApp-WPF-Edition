using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HandicraftApp
{
    class ItemViewDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement? element = container as FrameworkElement;
            if (element != null && item != null && item is Item) 
            {
                Item? currentItem = item as Item;

                if (currentItem.TableName == "crochetHooks")
                {
                    return element.FindResource("crochetHooksTemplate") as DataTemplate;
                }
                else if (currentItem.TableName == "crochetThreads")
                {
                    return element.FindResource("crochetThreadsTemplate") as DataTemplate;
                }
                else if (currentItem.TableName == "sewingThreads")
                {
                    return element.FindResource("sewingThreadsTemplate") as DataTemplate;
                }
            }
            return null;
            //return base.SelectTemplate(item, container);
        }
    }
}
