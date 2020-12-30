using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.WebAPI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }
    }
}