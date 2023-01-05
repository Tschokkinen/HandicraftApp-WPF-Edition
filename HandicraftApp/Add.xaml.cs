using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace HandicraftApp
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        string? selection;

        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? buttonTag = button.Tag as string;

            switch (buttonTag) 
            {
                case "Save": // NOTE TO SELF: CHECK FOR EMPTY TEXT BOXES!
                    Save();
                    break;
                case "crochetHooks":
                    selection = buttonTag;
                    TextBox1_Label.Content = "Koko";
                    TextBox2_Label.Content = "Materiaali";
                    TextBox1_Stack.Visibility = Visibility.Visible;
                    TextBox2_Stack.Visibility = Visibility.Visible;
                    TextBox3_Stack.Visibility = Visibility.Collapsed;
                    TextBox4_Stack.Visibility = Visibility.Collapsed;
                    SaveButton.Visibility = Visibility.Visible;
                    break;
                case "crochetThreads":
                    selection = buttonTag;
                    TextBox1_Label.Content = "Koko";
                    TextBox2_Label.Content = "Materiaali";
                    TextBox3_Label.Content = "Väri";
                    TextBox1_Stack.Visibility = Visibility.Visible;
                    TextBox2_Stack.Visibility = Visibility.Visible;
                    TextBox3_Stack.Visibility = Visibility.Visible;
                    TextBox4_Stack.Visibility = Visibility.Collapsed;
                    SaveButton.Visibility = Visibility.Visible;
                    break;
                case "Cancel":
                    DialogResult = true;
                    break;
            }
            
        }

        // NOTE TO SELF: MAKE SECTION LESS HARD CODED.
        private void Save()
        {
            string? size;
            string? material;
            string? colour;
            string? tableEntry;

            switch(selection)
            {
                case "crochetHooks":
                    size = TextBox1.Text.ToString();
                    if (size.Contains(','))
                    {
                        size = size.Replace(',', '.');
                    }
                    material = TextBox2.Text.ToString();
                    Debug.WriteLine("size " + size);
                    tableEntry = $"INSERT INTO crochetHooks (id, size, material) values (NULL, {size}, '{material}')";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                case "crochetThreads":
                    size = TextBox1.Text.ToString();
                    if (size.Contains(','))
                    {
                        size = size.Replace(',', '.');
                    }
                    material = TextBox2.Text.ToString();
                    colour = TextBox3.Text.ToString();
                    tableEntry = $"INSERT INTO crochetThreads (id, size, material, colour) values (NULL, {size}, '{material}', '{colour}')";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                default:
                    DialogResult = true;
                    break;
            }
        }
    }
}
