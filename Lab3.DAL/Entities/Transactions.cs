using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab3.DAL
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Sum { get; set; }
        public DateTime DateTime { get; set; }

        public TransactionType Type { get; set; }
        public bool Profitable { get; set; } = false;
        [Required]
        public virtual Card Card { get; set; }
    }

    public enum TransactionType
    {
        OnlinePayment = 1,
        CafesAndRestaurants,
        Products,
        Books,
        AdditionMoney,
        TransferToAnotherCard,
        Other
    }
}
