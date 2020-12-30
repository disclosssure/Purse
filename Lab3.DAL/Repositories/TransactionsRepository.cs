using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public class TransactionsRepository : Repository<Transactions>, ITransactionsRepository
    {
        public TransactionsRepository(MyDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Transactions> GetAddingTransactions(int cardId)
        {
            return MyDbContext.Transactions.Where(x => x.Card.Id == cardId && x.Profitable == true).ToList();
        }

        public IEnumerable<Transactions> GetSpendingTransactions(int cardId)
        {
            return MyDbContext.Transactions.Select(x => x).Where(x => x.Card.Id == cardId && x.Profitable == false).ToList();
        }

        public IEnumerable<Transactions> GetTransactionsWithType(int cardId, int type)
        {
            return MyDbContext.Transactions.Select(x => x)
                              .Where(a => a.Card.Id == cardId && a.Type.CompareTo((TransactionType)type) == 0).ToList();
        }

        IEnumerable<Transactions> ITransactionsRepository.GetTransactionsWithCardId(int cardId)
        {
            return MyDbContext.Transactions.Select(x => x).Where(a => a.Card.Id == cardId).ToList();
        }

        // Вивів у властивість, щоб не прописувати кожного разу в методі і отримати доступ до Transactions
        public MyDbContext MyDbContext
        {
            get { return Context as MyDbContext; }
        }
    }
}
