using verkiezingPartijProject3.Classes;
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

namespace verkiezingPartijProject3
{
    /// <summary>
    /// Interaction logic for beheerPartij.xaml
    /// </summary>
    public partial class beheerPartij : Window
    {
        beheerDB _dbBeheer = new beheerDB();
        public beheerPartij()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable partij = _dbBeheer.SelectPartij();
            if (partij != null)
            {
                dgPartij.ItemsSource = partij.DefaultView;
            }
        }

        private void btnCreatepar_Click(object sender, RoutedEventArgs e)
        {

            if (_dbBeheer.InsertPartij(tbNaam.Text, tbAdres.Text, tbPostcode.Text, tbGemeente.Text, tbEmailAdres.Text, tbTelefoonnummer.Text))
            {
                MessageBox.Show($"Partij aangemaakt");
            }
            else
            {
                MessageBox.Show($"Partij mislukt");
            }

            FillDataGrid();
        }

        private void btnUpdatepar_Click(object sender, RoutedEventArgs e)
        {
            if (_dbBeheer.UpdatePartij(tbId.Text, tbNaam.Text, tbAdres.Text, tbPostcode.Text, tbGemeente.Text, tbEmailAdres.Text, tbTelefoonnummer.Text))
            {
                MessageBox.Show($"Student {tbId.Text} aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van . {tbId.Text} . mislukt");
            }

            FillDataGrid();
        }

        private void dgPartij_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbId.Text = dr["partij_id"].ToString();
                tbNaam.Text = dr["naam"].ToString();
                tbAdres.Text = dr["adres"].ToString();
                tbPostcode.Text = dr["postcode"].ToString();
                tbGemeente.Text = dr["gemeente"].ToString();
                tbEmailAdres.Text = dr["emailadres"].ToString();
                tbTelefoonnummer.Text = dr["telefoonnummer"].ToString();

                /*btnUpdatepar.IsEnabled = true;
                btnDeletepar.IsEnabled = true;
                btnCreatepar.IsEnabled = false;*/
            }
        }

        private void btnDeletepar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgPartij.SelectedItem as DataRowView;

            if (_dbBeheer.DeletePartij(selectedRow["partij_id"].ToString()))
            {
                MessageBox.Show($"Student {selectedRow["partij_id"]} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {selectedRow["partij_id"]} mislukt");
            }

            FillDataGrid();
        }
    }
}
