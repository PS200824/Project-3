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
    /// Interaction logic for beheerVerkiezingPartij.xaml
    /// </summary>
    public partial class beheerVerkiezingPartij : Window
    {
        beheerDB _dbBeheer = new beheerDB();
        public beheerVerkiezingPartij()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable partij = _dbBeheer.SelectVerkiezingsPartij();
            if (partij != null)
            {
                dgVerPartij.ItemsSource = partij.DefaultView;
            }
        }
    }
}
