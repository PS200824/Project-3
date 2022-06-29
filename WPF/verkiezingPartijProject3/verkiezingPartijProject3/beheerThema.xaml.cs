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
    /// Interaction logic for beheerThema.xaml
    /// </summary>
    public partial class beheerThema : Window
    {
        beheerDB _dbBeheer = new beheerDB();
        public beheerThema()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable partij = _dbBeheer.SelectThema();
            if (partij != null)
            {
                dgThema.ItemsSource = partij.DefaultView;
            }
        }

        private void dgThema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbThema.Text = dr["thema"].ToString();
                tbId.Text = dr["thema_id"].ToString();

                /*btnCreateth.IsEnabled = false;
                btnUpdateth.IsEnabled = true;
                btnDeleteth.IsEnabled = true;*/
            }
        }

        private void btnDeleteth_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgThema.SelectedItem as DataRowView;

            if (_dbBeheer.DeleteThema(selectedRow["thema_id"].ToString()))
            {
                MessageBox.Show($"Student {selectedRow["thema_id"]} verwijderd");
                tbThema.Clear();
            }
            else
            {
                MessageBox.Show($"Verwijderen van {selectedRow["thema_id"]} mislukt");
            }
            FillDataGrid();
        }

        private void btnUpdateth_Click(object sender, RoutedEventArgs e)
        {
            if (_dbBeheer.UpdateThema(tbId.Text, tbThema.Text))
            {
                MessageBox.Show($"Student {tbId.Text} aangepast");
                tbThema.Clear();
            }
            else
            {
                MessageBox.Show($"Aanpassen van . {tbId.Text} . mislukt");
            }
            FillDataGrid();
        }

        private void btnCreateth_Click(object sender, RoutedEventArgs e)
        {
            if (_dbBeheer.InsertThema(tbThema.Text))
            {
                MessageBox.Show($"Thema aangemaakt");
                tbThema.Clear();
            }
            else
            {
                MessageBox.Show($"Partij mislukt");
            }
            FillDataGrid();
        }
    }
}
