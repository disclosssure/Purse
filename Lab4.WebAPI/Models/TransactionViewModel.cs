using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.WebAPI.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Sum { get; set; }
        public DateTime DateTime { get; set; }

        public TransactionTypeView Type { get; set; }
        public int CardId { get; set; }
    }

    public enum TransactionTypeView
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