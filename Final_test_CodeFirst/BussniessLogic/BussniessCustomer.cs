using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class BussniessCustomer
    {
        Context context = new Context();
        Generality ge = new Generality();
        public DataTable getCustomer()
        {
            var cuslist =
               (from p in context.Customers
                select new {
                    Id = p.Id,
                    Name=p.Name,
                    NumberPhone = p.NumberPhone,
                    Address=p.Address,
                    Gender=p.Gender
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public DataTable FindNumberPhone(string numberphone)
        {
            var cuslist =
               (from p in context.Customers
                where p.NumberPhone.Contains(numberphone)
                select new
                {
                    Id = p.Id,
                    Name = p.Name,
                    NumberPhone = p.NumberPhone,
                    Address = p.Address,
                    Gender = p.Gender
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public void DeleteCustomer(string StaffID)
        {
            var Staff = (from s in context.Customers
                        where s.Id == StaffID
                        select s).FirstOrDefault();
            context.Customers.Remove(Staff);
            context.SaveChanges();
        }
        public void AddCustomer(string id, string FullName,
             string Phone, string Address, string Gender)
        {
            Customer cus = new Customer();
            cus.Id = id;
            cus.Name = FullName;
            cus.NumberPhone = Phone;
            cus.Address = Address;
            cus.Gender = Gender;
            context.Customers.Add(cus);
            context.SaveChanges();
        }
        public void UpdateCustomer(string id, string FullName,
             string Phone, string Address, string Gender)
        {
            Customer cus = (from p in context.Customers
                            where p.Id == id
                            select p).First();

            cus.Id = id;
            cus.Name = FullName;
            cus.NumberPhone = Phone;
            cus.Address = Address;
            cus.Gender = Gender;
            context.SaveChanges();
        }
    }
}
