using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public interface ITransactionsRepository : IRepository<Transactions>
    {
        IEnumerable<Transactions> GetTransactionsWithType(int cardId, int type);
        IEnumerable<Transactions> GetSpendingTransactions(int cardId);
        IEnumerable<Transactions> GetAddingTransactions(int cardId);
        IEnumerable<Transactions> GetTransactionsWithCardId(int cardId);
    }
}
