using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.WebAPI.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double TotalMoney { get; set; }
        public int UserId { get; set; }
    }
}