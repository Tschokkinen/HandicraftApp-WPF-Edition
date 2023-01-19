using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace HandicraftApp
{
    /// <summary>
    /// Interaction logic for Crochet.xaml
    /// </summary>
    public partial class Crochet : Page
    {
        public ObservableCollection<Item> MyItems = new ObservableCollection<Item>();
        Item? selected;
        List<Item> items = new List<Item>();
        private Origins origin = Origins.Crochet;

        public Crochet()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = ((Button)(sender));
            string? buttonTag = button.Tag as string;

            switch(buttonTag)
            {
                case "Hooks":
                    items.Clear();
                    items = Database.GetTableData("crochetHooks", "SELECT * FROM crochetHooks");
                    UpdateListBox(items);
                    SelectedLabel.Content = "Virkkuukoukut";
                    break;
                case "Threads":
                    items.Clear();
                    items = Database.GetTableData("crochetThreads", "SELECT * FROM crochetThreads");
                    UpdateListBox(items);
                    SelectedLabel.Content = "Virkkuulangat";
                    break;
                case "Add":
                    var add = new AddItem(origin);
                    add.ShowDialog();
                    break;
                case "Remove":
                    if(selected != null)
                    {
                        Database.RemoveTableData(selected.TableName, selected.Id);
                        MyItems.Remove(selected);
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
            CrochetBox.DataContext = MyItems;
        }

        private void crochet_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            selected = CrochetBox.SelectedItem as Item;
            //Debug.WriteLine("List box item clicked: " + selected?.Id.ToString());
            //Debug.WriteLine("List box item clicked: " + selected?.Size.ToString());
            //Debug.WriteLine("List box item clicked: " + selected?.Material.ToString());
        }
    }
}
