using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public class CardRepositories : Repository<Card>, ICardRepositories
    {
        public CardRepositories(MyDbContext myDbContext)
            : base(myDbContext)
        {
        }

        public IEnumerable<Card> GetCardsWithUserId(int userId)
        {
            return MyDbContext.Cards.Select(a => a).Where(a => a.User.Id == userId).ToList();
        }

        void ICardRepositories.Update(Card card)
        {
            MyDbContext.Entry(card).State = System.Data.Entity.EntityState.Modified;
        }

        public MyDbContext MyDbContext
        {
            get { return Context as MyDbContext; }
        }
    }
}
