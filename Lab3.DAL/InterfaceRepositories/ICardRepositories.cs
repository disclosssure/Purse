using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public interface ICardRepositories : IRepository<Card>
    {
        IEnumerable<Card> GetCardsWithUserId(int userId);
        void Update(Card card);
    }
}
