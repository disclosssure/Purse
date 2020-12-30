using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab3.DAL
{
    public class Card
    {
        public int Id { get; set; }
        [Required, MinLength(16), MaxLength(16)]
        public string Number { get; set; }
        public double TotalMoney { get; set; }
        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
