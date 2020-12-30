using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Sum { get; set; }
        public DateTime DateTime { get; set; }

        public TransactionTypeDTO Type { get; set; }
        public bool Profitable { get; set; }
        public int CardId { get; set; }
    }

    public enum TransactionTypeDTO
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
