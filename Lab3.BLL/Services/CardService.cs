using AutoMapper;
using Lab3.BLL.Infrastructure;
using Lab3.BLL.Interfaces;
using Lab3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL.Services
{
    public class CardService : ICardService
    {
        IUnitOfWork Database { get; set; }
        public CardService(IUnitOfWork iow)
        {
            Database = iow;
        }

        /// Card details by userId
        public CardDTO GetCardsById(int id)
        {
            if (id <= 0) throw new ArgumentException("This userId doesn't exist");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<Card, CardDTO>()
                                                             .ForMember(x => x.UserId, x => x.MapFrom(m => m.User.Id)))
                                                             .CreateMapper();
            var card = Database.Cards.Get(id);
            if (card == null)
                throw new ValidationException("Card not found", "Card");

            return mapper.Map<Card, CardDTO>(card);
        }

        public IEnumerable<CardDTO> GetCardsByUserId(int userId)
        {
            if (userId <= 0) throw new ArgumentException("This userId doesn't exist");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<Card, CardDTO>()
                                                             .ForMember(x => x.UserId, x => x.MapFrom(m => m.User.Id)))
                                                             .CreateMapper();
            var cards = Database.Cards.GetCardsWithUserId(userId);
            if (cards == null)
                throw new ValidationException("Cards not found", "Cards");

            return mapper.Map<IEnumerable<Card>, List<CardDTO>>(cards);
        }
       
        /// Spending money on this functionality
        public void MakeCosts(TransactionDTO transactionsDTO, string number = "")
        {
            if (transactionsDTO == null) throw new ArgumentNullException("This Transactions null");

            var card = Database.Cards.SingleOrDefault(x => x.Id == transactionsDTO.CardId);
            if (card == null)
                throw new ValidationException("Card for this transaction not found", "Cards");

            if (card.TotalMoney - transactionsDTO.Sum < 0)
                throw new ValidationException("Not enough money for this", "");

            Database.Transactions.Add(new Transactions()
            {
                Card = card,
                DateTime = DateTime.Now,
                Profitable = false,
                Sum = transactionsDTO.Sum,
                Type = (TransactionType)transactionsDTO.Type
            });

            card.TotalMoney = card.TotalMoney - transactionsDTO.Sum;

            if (transactionsDTO.Type == TransactionTypeDTO.TransferToAnotherCard && number.Length == 16)
                TransferMoneyToCard(transactionsDTO, number);
            else
                throw new ValidationException("Incorrect number", "");

            Database.Cards.Update(card);
            Database.Save();
        }

        /// Transfer money to another card
        private void TransferMoneyToCard(TransactionDTO transactionDTO, string number)
        {
            var card = Database.Cards.SingleOrDefault(x => x.Number == number);
            if (card == null)
                throw new ValidationException("Card for this transaction not found", "Cards");

            Database.Transactions.Add(new Transactions()
            {
                Card = card,
                DateTime = DateTime.Now,
                Profitable = true,
                Sum = transactionDTO.Sum,
                Type = TransactionType.AdditionMoney
            });

            card.TotalMoney = card.TotalMoney + transactionDTO.Sum;

            Database.Cards.Update(card);
            Database.Save();
        }
        /// Receive all transactions by cost or revenue
        public IEnumerable<TransactionDTO> GetTransactionByProfit(int cardId, bool profit)
        {
            if (cardId <= 0)
                throw new ArgumentException("This userId doesn't exist");

            IEnumerable<Transactions> trans;
            if (profit)
                trans = Database.Transactions.GetAddingTransactions(cardId);
            else
                trans = Database.Transactions.GetSpendingTransactions(cardId);


            if (trans == null || trans.Count() == 0)
                throw new ValidationException("Transactions by profit not found", "Transactions");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<Transactions, TransactionDTO>()
                                                .ForMember(x => x.CardId, x => x.MapFrom(m => m.Card.Id))
                                                .ForMember(x => x.Type, x => x.MapFrom(m => m.Type)))
                                                .CreateMapper();

            return mapper.Map<IEnumerable<Transactions>, List<TransactionDTO>>(trans);
        }


        /// Receive all transactions by type
        public IEnumerable<TransactionDTO> GetTransactionByType(int cardId, TransactionTypeDTO type)
        {
            if (cardId <= 0)
                throw new ArgumentException("This userId doesn't exist");
            var trans = Database.Transactions.GetTransactionsWithType(cardId, (int)type);

            if (trans == null || trans.Count() == 0)
                throw new ValidationException($"Transactions by type {type.ToString()} not found", "Transactions");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<Transactions, TransactionDTO>()
                                                .ForMember(x => x.CardId, x => x.MapFrom(m => m.Card.Id))
                                                .ForMember(x => x.Type, x => x.MapFrom(m => m.Type)))
                                                .CreateMapper();

            return mapper.Map<IEnumerable<Transactions>, List<TransactionDTO>>(trans);
        }

        /// Receive all transactions
        public IEnumerable<TransactionDTO> GetAllTransaction(int cardId)
        {
            if (cardId <= 0)
                throw new ArgumentException("This userId doesn't exist");
            var trans = Database.Transactions.GetTransactionsWithCardId(cardId);

            if(trans == null || trans.Count() == 0)
                throw new ValidationException("Transactions not found", "Transactions");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<Transactions, TransactionDTO>()
                                                .ForMember(x => x.CardId, x => x.MapFrom(m => m.Card.Id))
                                                .ForMember(x => x.Type, x => x.MapFrom(m => m.Type)))
                                                .CreateMapper();

            return mapper.Map<IEnumerable<Transactions>, List<TransactionDTO>>(trans);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
