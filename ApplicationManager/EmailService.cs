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

namespace ApplicationManager
{
   public class EmailService
    {
        DatabaseService database = new DatabaseService();
        public void SendEmail(DateTime startTime, DateTime endTime)
        {
            var login = new NetworkCredential("doctor.weight1@gmail.com", "mlodetygrysy");
            var client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            var msg = new MailMessage { From = new MailAddress("doctor.weight1@gmail.com", "Telemedycyna", Encoding.UTF8) };
            msg.To.Add(new MailAddress ("dpiechnik2@gmail.com"));
            msg.Subject = "TELEMEDYCYNA";
            msg.Body = "testowy mail";
            // msg.Body = database.GetValuesByDate(startTime, endTime).ToString();
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
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
    }
}
