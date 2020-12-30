using Lab3.BLL;
using Lab3.BLL.Services;
using Lab3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3_5MultiLayer
{
    class Program
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            //using (var unitOfWork = new UnitOfWork(new MyDbContext()))
            //{
            //    Console.WriteLine("Task 1");
            //    var test = unitOfWork.Cards.GetCardsWithUserId(2);
            //    foreach (var item in test)
            //    {
            //        Console.WriteLine(item.Number);
            //    }

            //    Console.WriteLine("=========================");
            //    var t = unitOfWork.Cards.Find(x => x.User.Id == 2);
            //    foreach (var item in t)
            //    {
            //        Console.WriteLine(item.Number);
            //    }
            //}

            //UserService userService = new UserService();



            //var user = userService.GetUserById(1);

            //Console.WriteLine(user);


            //TransactionDTO transactionDto = new TransactionDTO()
            //{
            //    CardId = 1,
            //    DateTime = DateTime.Now,
            //    Profitable = false,
            //    Sum = 15,
            //    Type = TransactionTypeDTO.Products
            //};
            //cardService.MakeCosts(transactionDto);

            //try
            //{
            //    var cardTrans = cardService.GetTransactionByProfit(45, true);
            //    foreach (var item in cardTrans)
            //    {
            //        Console.WriteLine(item.DateTime);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}




            //var card = cardService.GetCardsByUserId(1);
            //foreach (var item in card)
            //{
            //    Console.WriteLine(item.TotalMoney);
            //}

            Console.ReadLine();
        }


    }
}
