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
    /// Interaction logic for EnterYourWeight.xaml
    /// </summary>
    public partial class EnterYourWeight : Page
    {
        Archive archive;
        DatabaseService databaseService;
        DateTime date = DateTime.Now;
        MessageWin messageWin;
        public EnterYourWeight()
        {
            InitializeComponent();
            archive = new Archive();
            databaseService = new DatabaseService();
            messageWin = new MessageWin();
        }

        private void ArchiveBTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(archive);
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                databaseService.SendValuesToDatabase(Convert.ToInt32(CurrentWeight.Text), date, Description.Text, databaseService.GetUserID(MainPage.SendLogin));

                //MessageBox.Show("Pomyślnie dodano wpis do bazy danych!");
                messageWin.MessageLabel.Content = "Pomyślnie dodano wpis do bazy danych.";
                messageWin.Show();
            }
            catch (Exception)
            {
                messageWin.MessageLabel.Content = "Coś poszło nie tak..";
                messageWin.Show();
                //MessageBox.Show("Ups!");

            }
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            SendPage send = new SendPage();
            this.NavigationService.Navigate(send);
        }
    }
}
