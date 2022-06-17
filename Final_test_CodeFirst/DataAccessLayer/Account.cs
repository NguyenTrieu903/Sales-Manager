using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class Account
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Displayname { get; set; }
        public int role { get; set; }
    }
}
