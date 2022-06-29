using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using verkiezingPartijProject3.Classes;

namespace verkiezingPartijProject3
{
    /// <summary>
    /// Interaction logic for beheerVerzkiezingsoorten.xaml
    /// </summary>
    public partial class beheerVerzkiezingsoorten : Window
    {
        beheerDB _dbBeheer = new beheerDB();
        public beheerVerzkiezingsoorten()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable partij = _dbBeheer.SelectVerkiezingsoorten();
            if (partij != null)
            {
                dgVerkSo.ItemsSource = partij.DefaultView;
            }
        }

        private void dgVerkSo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteVerS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateVerS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateVerS_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
