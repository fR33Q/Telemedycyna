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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static string SendLogin;
        
        NewUser newUser;
        EnterYourWeight weightPage;
        DatabaseService databaseService;
        public MainPage()
        {
            InitializeComponent();
            newUser = new NewUser();
            weightPage = new EnterYourWeight();
            databaseService = new DatabaseService();
        }

        private void NewAccountBTN_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(newUser);
        }

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            databaseService.LogIn(PasswordBox.Password, tbUserName.Text);
            Send();
            this.NavigationService.Navigate(weightPage);
        }

        #region Send
        private void Send()
        {
            SendLogin = tbUserName.Text;

        }
        #endregion

       
        
    }
}
