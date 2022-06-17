using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class BussniessLogin
    {
        Context context = new Context();
        Generality ge = new Generality();
        public bool validate(string user, string password)
        {
            var query = from p in context.Accounts
                        where p.Username.Equals(user) && p.Password.Equals(password)
                        select p;
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddAccount (string username , string password , string displayname)
        {
            Account acc = new Account();
            acc.Username = username;
            acc.Password = password;
            acc.Displayname = displayname;
            acc.role = 1;
            context.Accounts.Add(acc);
            context.SaveChanges();
        }
        public void UpdatePassword(string username, string password)
        {
                Account acc = (from a in context.Accounts
                               where a.Username == username
                               select a).First();
                acc.Password = password;
                context.SaveChanges();
        }
    }
}
