using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandicraftApp
{
    /// <summary>
    /// Interaction logic for Sewing.xaml
    /// </summary>
    public partial class Sewing : Page
    {
        public ObservableCollection<Item> MyItems = new ObservableCollection<Item>();
        Item? selected;
        List<Item> items = new List<Item>();
        private Origins origin = Origins.Sewing;

        public Sewing()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = ((Button)(sender));
            string? buttonTag = button.Tag as string;

            switch (buttonTag)
            {
                case "Threads":
                    items.Clear();
                    items = Database.GetTableData("sewingThreads", "SELECT * FROM sewingThreads");
                    UpdateListBox(items);
                    SelectedLabel.Content = "Ompelulangat";
                    break;
                case "Patterns":
                    items.Clear();
                    items = Database.GetTableData("sewingPatterns", "SELECT * FROM sewingPatterns");
                    UpdateListBox(items);
                    SelectedLabel.Content = "Kaavat";
                    break;
                case "Fabrics":
                    items.Clear();
                    items = Database.GetTableData("sewingFabrics", "SELECT * FROM sewingFabrics");
                    UpdateListBox(items);
                    SelectedLabel.Content = "Kankaat";
                    break;
                case "Add":
                    var add = new AddItem(origin);
                    add.ShowDialog();
                    break;
                case "Remove":
                    if (selected != null)
                    {
                        //Database.RemoveTableData(selected.TableName, selected.Id);
                        //MyItems.Remove(selected);
                    }
                    break;
                default:
                    Debug.WriteLine("Default.");
                    break;
            }
        }

        // Update ListBox items.
        private void UpdateListBox(List<Item> items)
        {
            MyItems.Clear();
            foreach (Item item in items)
            {
                MyItems.Add(item);
                Debug.WriteLine("Material: " + item.Material);
                Debug.WriteLine("Table name: " + item.TableName);
            }
            SewingBox.DataContext = MyItems;
        }

        private void sewing_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            selected = SewingBox.SelectedItem as Item;
            //Debug.WriteLine("List box item clicked: " + selected?.Id.ToString());
            //Debug.WriteLine("List box item clicked: " + selected?.Size.ToString());
            //Debug.WriteLine("List box item clicked: " + selected?.Material.ToString());
        }
    }
}
