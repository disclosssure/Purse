using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
   public  interface IUnitOfWork : IDisposable
    {
        ICardRepositories Cards { get; }
        IUserRepositories Users { get; }
        ITransactionsRepository Transactions { get; }
        int Save();
    }
}
