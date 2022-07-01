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
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbId.Text = dr["verkiezingsoort_id"].ToString();
                tbVerkiezingsoort.Text = dr["verkiezingsoort"].ToString();

            }
        }

        private void btnDeleteVerS_Click(object sender, RoutedEventArgs e)
        {
           
            DataRowView selectedRow = dgVerkSo.SelectedItem as DataRowView;

            if (_dbBeheer.DeleteVerkiezingsoort(selectedRow["verkiezingsoort_id"].ToString()))
            {
                MessageBox.Show($"Verkiezingsoort {selectedRow["verkiezingsoort_id"]} verwijderd");
                tbVerkiezingsoort.Clear();
            }
            else
            {
                MessageBox.Show($"Verwijderen van verkiezingsoort {selectedRow["verkiezingsoort_id"]} mislukt");
            }
            FillDataGrid();
            
        }

        private void btnUpdateVerS_Click(object sender, RoutedEventArgs e)
        {
            if (_dbBeheer.UpdateVerkiezingsoort(tbId.Text, tbVerkiezingsoort.Text))
            {
                MessageBox.Show($"Verkiezingsoort {tbId.Text} aangepast");
                tbVerkiezingsoort.Clear();
            }
            else
            {
                MessageBox.Show($"Aanpassen van . {tbId.Text} . mislukt");
            }
            FillDataGrid();
        }

        private void btnCreateVerS_Click(object sender, RoutedEventArgs e)
        {
            if (_dbBeheer.InsertVerkiezingsoorten(tbVerkiezingsoort.Text))
            {
                MessageBox.Show($"Verkiezingsoort aangemaakt");
                tbVerkiezingsoort.Clear();
            }
            else
            {
                MessageBox.Show($"Verkiezingsoort mislukt");
                
            }
            FillDataGrid();
        }
    }
}
