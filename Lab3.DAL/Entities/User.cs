using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string Login { get; set; }
        [Required, MinLength(4), MaxLength(25)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Range(18, 90)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
