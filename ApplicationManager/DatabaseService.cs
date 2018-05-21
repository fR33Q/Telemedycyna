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

        public void RegisterNewUser(string username, string password)
        {
            using (var db = new FMWEntities())
            {
                Users user = new Users();
                user.Username = username;
                user.Password = password;


                var _user = db.Set<Users>();
                _user.Add(user);
                db.SaveChanges();


            }
        }
    }
}
