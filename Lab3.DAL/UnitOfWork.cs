using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            Cards = new CardRepositories(_context);
            Transactions = new TransactionsRepository(_context);
            Users = new UserRepositories(_context);
        }

        public ICardRepositories Cards { get; private set; }

        public IUserRepositories Users { get; private set; }

        public ITransactionsRepository Transactions { get; private set; }

        public int Save()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
