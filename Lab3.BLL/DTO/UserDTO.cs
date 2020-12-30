using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }

    }
}
