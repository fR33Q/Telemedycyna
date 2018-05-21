using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ApplicationManager
{
    public class DatabaseService
    {
        public bool LogIn(string passwordBox, string tbUserName)
        {
            using (var db = new FMWEntities())
            {
                db.Database.Connection.Open();
                Users user = db.Users.SingleOrDefault(x => x.Username == tbUserName);

                if (user != null)
                {
                    if (user.Password == passwordBox)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
