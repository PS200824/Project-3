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

        public void FillCombobox()
        {
            DataTable partij = _dbBeheer.SelectPartij();
            if (partij != null)
            {
                cbPartij.ItemsSource = partij.DefaultView;
            }

            DataTable standpunt = _dbBeheer.SelectStandpunt();
            if (standpunt != null)
            {
                cbStandpunt.ItemsSource = standpunt.DefaultView;
            }

            //Get selected item from comboBox Thema.
            /*DataTable tId = (DataTable)cbThema.SelectedItem;*/
        }

        private void btnDeleteSta_Click(object sender, RoutedEventArgs e)
        {
            int part = (int)cbPartij.SelectedValue;
            int stanP = (int)cbStandpunt.SelectedValue;

            _dbBeheer.DeleteStandpunten(part, stanP, tbMe.Text);

            FillDataGrid();
        }

        private void btnUpdateSta_Click(object sender, RoutedEventArgs e)
        {
            int part = (int)cbPartij.SelectedValue;
            int stanP = (int)cbStandpunt.SelectedValue;

            _dbBeheer.UpdateStandpunten(part, stanP, tbMe.Text);

            FillDataGrid();
        }

        private void btnCreateSta_Click(object sender, RoutedEventArgs e)
        {
            int part = (int)cbPartij.SelectedValue;
            int stanP = (int)cbStandpunt.SelectedValue;

            _dbBeheer.InsertStandpunten(part, stanP, tbMe.Text);

            FillDataGrid();

        }

        private void dgStandpunten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbMe.Text = dr["mening"].ToString();

                /*btnUpdatepar.IsEnabled = true;
                btnDeletepar.IsEnabled = true;
                btnCreatepar.IsEnabled = false;*/
            }
        }
    }
}
