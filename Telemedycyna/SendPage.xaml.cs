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
using ApplicationManager;
namespace Telemedycyna
{
    /// <summary>
    /// Logika interakcji dla klasy SendPage.xaml
    /// </summary>
    public partial class SendPage : Page
    {
        EmailService email = new EmailService();
        public SendPage()
        {
            InitializeComponent();

        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            var dates = Calendar.SelectedDates;
            email.SendEmail(dates[0], dates[1]);
        }
    }
}
