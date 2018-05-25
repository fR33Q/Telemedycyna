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
using System.Windows.Shapes;

namespace Telemedycyna
{
    /// <summary>
    /// Interaction logic for MessageWin.xaml
    /// </summary>
    public partial class MessageWin : Window
    {
        public MessageWin()
        {
            InitializeComponent();
        }

        private void AcceptBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
