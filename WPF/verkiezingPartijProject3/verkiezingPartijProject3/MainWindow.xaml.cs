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

namespace verkiezingPartijProject3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btPartij_Click(object sender, RoutedEventArgs e)
        {
            beheerPartij win1 = new beheerPartij();
            win1.Show();
        }

        private void btThema_Click(object sender, RoutedEventArgs e)
        {
            beheerThema win2 = new beheerThema();
            win2.Show();
        }

        private void btStandpunten_Click(object sender, RoutedEventArgs e)
        {
            beheerStandpunten win3 = new beheerStandpunten();
            win3.Show();
        }

        private void btVerkSoorten_Click(object sender, RoutedEventArgs e)
        {
            beheerVerzkiezingsoorten win4 = new beheerVerzkiezingsoorten();
            win4.Show();
        }

        private void btVerkPartij_Click(object sender, RoutedEventArgs e)
        {
            beheerVerkiezingPartij win5 = new beheerVerkiezingPartij();
            win5.Show();
        }

        private void btVerkiezingen_Click(object sender, RoutedEventArgs e)
        {
            beheerVerkiezingen win6 = new beheerVerkiezingen();
            win6.Show();
        }
    }
}
