using System;
using System.Collections.Generic;
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
    /// Interaction logic for HandicraftAppHome.xaml
    /// </summary>
    public partial class HandicraftAppHome : Page
    {
        public HandicraftAppHome()
        {
            Database.CreateDatabase();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            // Misc oli siis uusi sivu!
            //Misc misc = new Misc(this.peopleListBox.SelectedItem);
            //this.NavigationService.Navigate(misc);
            Button button = ((Button)sender);
            string? buttonTag = button.Tag as string;

            switch(buttonTag)
            {
                case "Crochet":
                    Crochet crochet = new Crochet();
                    this.NavigationService.Navigate(crochet);
                    break;
                case "Sewing":
                    Sewing sewing = new Sewing();
                    this.NavigationService.Navigate(sewing);
                    break;
            }
        }
    }
}
