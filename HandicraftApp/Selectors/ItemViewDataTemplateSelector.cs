using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HandicraftApp.Enums;
using HandicraftApp.Models;

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

                if (currentItem.TableName == TableNames.CrochetHooks)
                {
                    return element.FindResource("crochetHooksTemplate") as DataTemplate;
                }
                else if (currentItem.TableName == TableNames.CrochetThreads)
                {
                    return element.FindResource("crochetThreadsTemplate") as DataTemplate;
                }
                else if (currentItem.TableName == TableNames.SewingThreads)
                {
                    return element.FindResource("sewingThreadsTemplate") as DataTemplate;
                }
                else if (currentItem.TableName == TableNames.SewingPatterns)
                {
                    return element.FindResource("sewingPatternsTemplate") as DataTemplate;
                }
                else if (currentItem.TableName == TableNames.SewingFabrics)
                {
                    return element.FindResource("sewingFabricsTemplate") as DataTemplate;
                }
            }
            return null;
            //return base.SelectTemplate(item, container);
        }
    }
}
