using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    internal sealed class Initializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);

            var user = new User
            {
                Login = "deniar.dev",
                Password = "1111",
                Age = 62,
                Name = "Vitya",
                Surname = "BigBoss"
            };

            var card = new Card
            {
                Number = "1425789654123564",
                TotalMoney = 2000,
                User = user
            };

            context.Transactions.Add(new Transactions
            {
                Sum = 100,
                Type = TransactionType.OnlinePayment,
                DateTime = new DateTime(2017, 10, 5, 17, 45, 55),
                Card = card
            });

            context.Transactions.Add(new Transactions
            {
                Sum = 720,
                Type = TransactionType.Books,
                DateTime = new DateTime(2017, 11, 7, 12, 55, 57),
                Card = card
            });

            context.Transactions.Add(new Transactions
            {
                Sum = 25,
                Type = TransactionType.CafesAndRestaurants,
                DateTime = new DateTime(2017, 11, 8, 16, 34, 21),
                Card = card
            });


            var user1 = new User
            {
                Login = "Volodya",
                Password = "111111",
                Age = 19,
                Name = "Vova",
                Surname = "Dol"
            };

            var card1 = new Card
            {
                Number = "3467579468945768",
                TotalMoney = 45782,
                User = user1
            };

            context.Transactions.Add(new Transactions
            {
                Sum = 110,
                Type = TransactionType.OnlinePayment,
                DateTime = new DateTime(2018, 1, 27, 7, 55, 55),
                Card = card1
            });


            context.Transactions.Add(new Transactions
            {
                Sum = 750,
                Type = TransactionType.Books,
                DateTime = new DateTime(2019, 1, 12, 7, 55, 55),
                Card = card1
            });

            var card2 = new Card
            {
                Number = "1111111111111111",
                TotalMoney = 3700,
                User = user1
            };


            context.Transactions.Add(new Transactions
            {
                Sum = 110,
                Type = TransactionType.CafesAndRestaurants,
                DateTime = new DateTime(2019, 10, 27, 17, 55, 55),
                Card = card2
            });

            context.Transactions.Add(new Transactions
            {
                Sum = 110,
                Type = TransactionType.OnlinePayment,
                DateTime = new DateTime(2020, 1, 1, 18, 47, 25),
                Card = card2
            });

            context.SaveChanges();
        }
    }
}
