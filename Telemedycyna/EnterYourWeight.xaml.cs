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

namespace Telemedycyna
{
    /// <summary>
    /// Interaction logic for EnterYourWeight.xaml
    /// </summary>
    public partial class EnterYourWeight : Page
    {
        Archive archive;
        public EnterYourWeight()
        {
            InitializeComponent();
            archive = new Archive();
        }

        private void ArchiveBTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(archive);
        }
    }
}
