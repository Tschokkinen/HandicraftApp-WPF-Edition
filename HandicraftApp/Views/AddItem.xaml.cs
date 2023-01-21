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
using HandicraftApp.Enums;

namespace HandicraftApp
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    /// 

    public partial class AddItem : Window
    {
        private Origins Origin { get; set; }

        string? selection;

        public AddItem()
        {

        }

        public AddItem(Origins origin)
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
        private void SetScene(Origins origin)
        {
            switch (origin)
            {
                case Origins.Crochet:
                    TypeName_Button1.Visibility = Visibility.Visible;
                    TypeName_Button1.Content = "Virkkuukoukku";
                    TypeName_Button1.Tag = "crochetHooks";
                    TypeName_Button2.Visibility = Visibility.Visible;
                    TypeName_Button2.Content = "Virkkuulanka";
                    TypeName_Button2.Tag = "crochetThreads";
                    TypeName_Button3.Visibility = Visibility.Collapsed;
                    break;
                case Origins.Sewing:
                    TypeName_Button1.Visibility = Visibility.Visible;
                    TypeName_Button1.Content = "Ompelulanka";
                    TypeName_Button1.Tag = "sewingThreads";
                    TypeName_Button2.Visibility = Visibility.Visible;
                    TypeName_Button2.Content = "Kaava";
                    TypeName_Button2.Tag = "sewingPatterns";
                    TypeName_Button3.Visibility = Visibility.Visible;
                    TypeName_Button3.Content = "Kangas";
                    TypeName_Button3.Tag = "sewingFabrics";
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? buttonTag = button.Tag as string;

            switch (buttonTag) 
            {
                case "Save":
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
                case "sewingThreads":
                    selection = buttonTag;
                    TextBox1_Label.Content = "Väri";
                    TextBox2_Label.Content = "Lisätietoja";
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
                case "sewingPatterns":
                    selection = buttonTag;
                    TextBox1_Label.Content = "Kaavan malli";
                    TextBox2_Label.Content = "Kaavojen koot";
                    TextBox3_Label.Content = "Lisätietoja";
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
                case "sewingFabrics":
                    selection = buttonTag;
                    TextBox1_Label.Content = "Kankaan materiaali";
                    TextBox2_Label.Content = "Kankaan alaluokka";
                    TextBox3_Label.Content = "Leveys (cm)";
                    TextBox4_Label.Content = "Korkeus (cm)";
                    TextBox1_Stack.Visibility = Visibility.Visible;
                    TextBox2_Stack.Visibility = Visibility.Visible;
                    TextBox3_Stack.Visibility = Visibility.Visible;
                    TextBox4_Stack.Visibility = Visibility.Visible;
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

        // NOTE TO SELF: MAKE SECTION LESS HARD CODED AND EASIER TO READ.
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

                    if (textBox1 == "" || textBox2 == "")
                    {
                        DisplayEmptyFieldMessage();
                        return;
                    }

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

                    if (textBox1 == "" || textBox2 == "" || textBox3 == "")
                    {
                        DisplayEmptyFieldMessage();
                        return;
                    }

                    tableEntry = $"INSERT INTO crochetThreads (id, size, material, colour) values (NULL, {textBox1}, '{textBox2}', '{textBox3}')";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                case "sewingThreads":
                    textBox1 = TextBox1.Text.ToString();
                    if (textBox1.Contains(','))
                    {
                        textBox1 = textBox1.Replace(',', '.');
                    }
                    textBox2 = TextBox2.Text.ToString();

                    if (textBox1 == "")
                    {
                        DisplayEmptyFieldMessage();
                        return;
                    }

                    if (textBox2 == "")
                    {
                        textBox2 = "-";
                    }

                    tableEntry = $"INSERT INTO sewingThreads (id, colour, optionalInfo) values (NULL, '{textBox1}', '{textBox2}')";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                case "sewingPatterns":
                    textBox1 = TextBox1.Text.ToString();
                    textBox2 = TextBox2.Text.ToString();
                    textBox3 = TextBox3.Text.ToString();

                    if (textBox1 == "" || textBox2 == "")
                    {
                        DisplayEmptyFieldMessage();
                        return;
                    }

                    if (textBox3 == "")
                    {
                        textBox3 = "-";
                    }

                    tableEntry = $"INSERT INTO sewingPatterns (id, patternModel, patternSizes, optionalInfo) values (NULL, '{textBox1}', '{textBox2}', '{textBox3}')";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                case "sewingFabrics":
                    textBox1 = TextBox1.Text.ToString();
                    textBox2 = TextBox2.Text.ToString();
                    textBox3 = TextBox3.Text.ToString();
                    textBox4 = TextBox4.Text.ToString();

                    if (textBox1 == "" || textBox2 == "")
                    {
                        DisplayEmptyFieldMessage();
                        return;
                    }

                    if (textBox3.Contains(','))
                    {
                        textBox3 = textBox3.Replace(',', '.');
                    }

                    if (textBox4.Contains(','))
                    {
                        textBox4 = textBox4.Replace(',', '.');
                    }

                    tableEntry = $"INSERT INTO sewingFabrics (id, mainType, subType, width, height) values (NULL, '{textBox1}', '{textBox2}', {textBox3}, {textBox4})";
                    Database.AddTableEntry(tableEntry);
                    DialogResult = true;
                    break;
                default:
                    DialogResult = true;
                    break;
            }
        }

        private void DisplayEmptyFieldMessage()
        {
            MessageBox.Show("Tyhjä kenttä", "EMPTY", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
