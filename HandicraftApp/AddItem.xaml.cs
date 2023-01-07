using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// 

    public partial class AddItem : Window
    {
        private string? Origin { get; set; }

        string? selection;

        public AddItem()
        {

        }

        public AddItem(string origin)
        {
            InitializeComponent();
            this.Origin = origin;
            BackButton.Visibility = Visibility.Collapsed;
            TextBox_Stack.Visibility = Visibility.Collapsed;
            TextBox1_Stack.Visibility = Visibility.Collapsed;
            TextBox2_Stack.Visibility = Visibility.Collapsed;
            TextBox3_Stack.Visibility = Visibility.Collapsed;
            TextBox4_Stack.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Visible;
            SetScene(Origin);
        }

        // Set button titles according to AddItem instantiator.
        private void SetScene(string origin)
        {
            switch (origin)
            {
                case "crochet":
                    TypeName_Button1.Content = "Virkkuukoukku";
                    TypeName_Button1.Tag = "crochetHooks";
                    TypeName_Button2.Content = "Virkkuulanka";
                    TypeName_Button2.Tag = "crochetThreads";
                    break;
            }
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
                case "Back":
                    BackButton.Visibility = Visibility.Collapsed;
                    TextBox_Stack.Visibility = Visibility.Collapsed;
                    TextBox1_Stack.Visibility = Visibility.Collapsed;
                    TextBox2_Stack.Visibility = Visibility.Collapsed;
                    TextBox3_Stack.Visibility = Visibility.Collapsed;
                    TextBox4_Stack.Visibility = Visibility.Collapsed;
                    SaveButton.Visibility = Visibility.Collapsed;
                    TypeName_Stack.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Visible;
                    break;
                case "crochetHooks":
                    selection = buttonTag;
                    TextBox1_Label.Content = "Koko";
                    TextBox2_Label.Content = "Materiaali";
                    TextBox1_Stack.Visibility = Visibility.Visible;
                    TextBox2_Stack.Visibility = Visibility.Visible;
                    TextBox3_Stack.Visibility = Visibility.Collapsed;
                    TextBox4_Stack.Visibility = Visibility.Collapsed;
                    TextBox_Stack.Visibility = Visibility.Visible;
                    TypeName_Stack.Visibility = Visibility.Collapsed;
                    BackButton.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Collapsed;
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
                    TextBox_Stack.Visibility = Visibility.Visible;
                    TypeName_Stack.Visibility = Visibility.Collapsed;
                    BackButton.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Collapsed;
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
            string? textBox1;
            string? textBox2;
            string? textBox3;
            string? textBox4;
            string? tableEntry;

            switch(selection)
            {
                case "crochetHooks":
                    textBox1 = TextBox1.Text.ToString();
                    if (textBox1.Contains(','))
                    {
                        textBox1 = textBox1.Replace(',', '.');
                    }
                    textBox2 = TextBox2.Text.ToString();

                    if (textBox1 == "" || textBox2 == "") return;

                    //Debug.WriteLine("size " + textBox1);
                    tableEntry = $"INSERT INTO crochetHooks (id, size, material) values (NULL, {textBox1}, '{textBox2}')";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                case "crochetThreads":
                    textBox1 = TextBox1.Text.ToString();
                    if (textBox1.Contains(','))
                    {
                        textBox1 = textBox1.Replace(',', '.');
                    }
                    textBox2 = TextBox2.Text.ToString();
                    textBox3 = TextBox3.Text.ToString();

                    if (textBox1 == "" || textBox2 == "" || textBox3 == "") return;

                    tableEntry = $"INSERT INTO crochetThreads (id, size, material, colour) values (NULL, {textBox1}, '{textBox2}', '{textBox3}')";
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
