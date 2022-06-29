using MySql.Data.MySqlClient;
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
    /// Interaction logic for beheerStandpunten.xaml
    /// </summary>
    public partial class beheerStandpunten : Window
    {
        beheerDB _dbBeheer = new beheerDB();
        public beheerStandpunten()
        {
            InitializeComponent();
            FillDataGrid();
            FillCombobox();
        }
        private void FillDataGrid()
        {
            DataTable standpunt = _dbBeheer.SelectStandpunten();
            if (standpunt != null)
            {
                dgStandpunten.ItemsSource = standpunt.DefaultView;

            }
        }

        private void FillCombobox()
        {
            DataTable partij = _dbBeheer.SelectPartij();
            if (partij != null)
            {
                cbPartij.ItemsSource = partij.DefaultView;
            }

            DataTable thema = _dbBeheer.SelectThema();
            if (thema != null)
            {
                cbThema.ItemsSource = thema.DefaultView;
            }

            DataTable standpunt = _dbBeheer.SelectStandpunt();
            if (standpunt != null)
            {
                cbStandpunt.ItemsSource = standpunt.DefaultView;
            }

            //Get selected item from comboBox Thema.
            /*DataTable tId = (DataTable)cbThema.SelectedItem;*/
            ComboBoxItem td = (ComboBoxItem)cbThema.SelectedItem;


        }

        private void btnDeleteSta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateSta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateSta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
