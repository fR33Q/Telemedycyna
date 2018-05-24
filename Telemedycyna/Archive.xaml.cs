using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using ApplicationManager;
using ApplicationManager.DatabaseModel;

namespace Telemedycyna
{
    /// <summary>
    /// Interaction logic for Archive.xaml
    /// </summary>
    public partial class Archive : Page
    {
        DatabaseService databaseService = new DatabaseService();
        
        public Archive()
        {
            InitializeComponent();
            
        }

        private void FillData()
        {
            var dates = Calendar.SelectedDates;
            try
            {
                listView.ItemsSource = databaseService.GetValuesByDate(dates[0], dates[1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano daty!");

            }
         
            
        }

        private void ShowBTN_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }
    }
}
