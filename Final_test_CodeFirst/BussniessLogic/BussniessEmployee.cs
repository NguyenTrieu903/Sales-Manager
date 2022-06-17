using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class BussniessEmployee
    {
        Context context = new Context();
        Generality ge = new Generality();
        public DataTable getEmployee()
        {
            var cuslist =
               (from p in context.Employees
                select new {
                    Id = p.Id,
                    FullName=p.FullName,
                    Gender=p.Gender,
                    DayofBirth=p.DayofBirth,
                    Address=p.Address,
                    NumberPhone=p.NumberPhone,
                    Identitycard=p.Identitycard,
                    Position=p.Position,
                    Salary=p.Salary
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public DataTable FindIdEmployee(string id)
        {
            var cuslist =
               (from p in context.Employees
                where p.Id.Contains(id)
                select new
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    DayofBirth = p.DayofBirth,
                    Address = p.Address,
                    NumberPhone = p.NumberPhone,
                    Identitycard = p.Identitycard,
                    Position = p.Position,
                    Salary = p.Salary
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public void DeleteEmployee(string StaffID)
        {
            var Staff = (from s in context.Employees
                         where s.Id == StaffID
                         select s).FirstOrDefault();
            context.Employees.Remove(Staff);
            context.SaveChanges();
        }
        public void AddEmployee(string id, string FullName, string Gender, DateTime DayofBirth, string Address,
             string Phone, string Identity, string Position, string Salary)
        {
            Employee e = new Employee();
            e.Id = id;
            e.FullName = FullName;
            e.Gender = Gender;
            e.DayofBirth = DayofBirth;
            e.Address = Address;
            e.NumberPhone = Phone;
            e.Identitycard = Identity;
            e.Position = Position;
            e.Salary = int.Parse(Salary);
            context.Employees.Add(e);
            context.SaveChanges();
        }
        public void UpdateEmployee(string id, string FullName, string Gender, DateTime DayofBirth, string Address,
             string Phone, string Identity, string Position, string Salary)
        {
            Employee e = (from p in context.Employees
                          where p.Id == id
                          select p).FirstOrDefault();

            e.Id = id;
            e.FullName = FullName;
            e.Gender = Gender;
            e.DayofBirth = DayofBirth;
            e.Address = Address;
            e.NumberPhone = Phone;
            e.Identitycard = Identity;
            e.Position = Position;
            e.Salary = int.Parse(Salary);
            context.SaveChanges();
        }
    }
}
