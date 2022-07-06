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
    /// Interaction logic for beheerVerkiezingen.xaml
    /// </summary>
    public partial class beheerVerkiezingen : Window
    {
        beheerDB _dbBeheer = new beheerDB();

        public beheerVerkiezingen()
        {
            InitializeComponent();
            FillDataGrid();
            FillCombobox();
        }

        private void FillDataGrid()
        {
            DataTable partij = _dbBeheer.SelectVerkiezingen();
            if (partij != null)
            {
                dgVerkiezing.ItemsSource = partij.DefaultView;
            }
        }

        private void dgVerkiezing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbId.Text = dr["verkiezing_id"].ToString();
                tbId2.Text = dr["verkiezingsoortID"].ToString();


                string datum = dr["datum"].ToString();

                DateTime enteredDate = DateTime.Parse(datum);

                dpDatum.SelectedDate = enteredDate;
            }
        }

        public void FillCombobox()
        {
            DataTable verS = _dbBeheer.SelectVerS();
            if (verS != null)
            {
                cbVerS.ItemsSource = verS.DefaultView;
            }

        }

        private void btnDeleteVerk_Click(object sender, RoutedEventArgs e)
        {
            string verk_id = tbId.Text;

            _dbBeheer.DeleteVerk(tbId.Text);

            MessageBox.Show($"Verkiezing " + verk_id + " is succesvol verwijderd.");

            FillDataGrid();
        }

        private void btnUpdateVerk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateVerk_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
