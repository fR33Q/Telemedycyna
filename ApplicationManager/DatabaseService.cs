using ApplicationManager.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace ApplicationManager
{
    public class DatabaseService
    {
        
        public bool LogIn(string passwordBox, string tbUserName)
        {
            using (var db = new WeightDBEntities())
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
            using (var db = new WeightDBEntities())
            {
                Users user = new Users();
                user.Username = username;
                user.Password = password;


                var _user = db.Set<Users>();
                _user.Add(user);
                db.SaveChanges();


            }
        }

        public void SendValuesToDatabase( int weight, DateTime? date, string description, int id)
        {
            
            try
            {
                using (var db = new WeightDBEntities())
                {
                    Weights weights = new Weights();
                    weights.UserID = id;
                    weights.Weight = weight;
                    weights.CreationDate = date;
                    weights.Description = description;


                    var _weight = db.Set<Weights>();
                    _weight.Add(weights);
                    db.SaveChanges();


                }
            }
            catch(Exception e)
            {
               e.ToString();
            }

        }

        public int GetUserID(string login)
        {
            using (var db = new WeightDBEntities())
            {
                var query = (from Users u in db.Users
                             where u.Username == login
                             select u.UserID).FirstOrDefault();
                return query;
            }
        }

        public List<Weights> GetValuesByDate(DateTime startDate, DateTime endDate)
        {
            using (var db = new WeightDBEntities())
            {
                var query = (from Weights w in db.Weights
                             where w.CreationDate >= startDate && w.CreationDate <= endDate
                             select w).ToList();

                return query;
            }

        }

    }
}
