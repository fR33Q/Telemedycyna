using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using ApplicationManager;
using System.ComponentModel;
using System.Windows;
using System.IO;

namespace ApplicationManager
{
   public class EmailService
    {
        DatabaseService database = new DatabaseService();
        public void SendEmail(DateTime startDate, DateTime endDate, string email, string body)
        {
            CreateTxtFile(startDate, endDate);
            Attachment data = new Attachment("wyniki.txt");
            var login = new NetworkCredential("doctor.weight1@gmail.com", "mlodetygrysy");
            var client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            var msg = new MailMessage { From = new MailAddress("doctor.weight1@gmail.com", "Telemedycyna", Encoding.UTF8) };
            msg.To.Add(new MailAddress (email));
            msg.Subject = "TELEMEDYCYNA";
            msg.Body = body;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Attachments.Add(data);
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
            string userstate = "sending..";
            client.SendAsync(msg, userstate);
        }

        private void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Anulowano");

            }
            else if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} {1}",e.UserState, e.Error));
            }
            else
            {

                MessageBox.Show("Wyslano maila");
            }
        }

        private void CreateTxtFile(DateTime startDate, DateTime endDate)
        {
            var list = database.GetValuesByDate(startDate, endDate);
            using (TextWriter tw = new StreamWriter("wyniki.txt"))
            {
                foreach (var item in list)
                {
                    tw.WriteLine(string.Format("Waga: {0} || Opis wyniku: {1} || Czas utworzenia: {2}", item.Weight, item.Description, item.CreationDate));
                }

                tw.Close();
            }


        }
    }
}
