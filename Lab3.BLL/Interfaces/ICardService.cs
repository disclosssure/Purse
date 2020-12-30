using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL.Interfaces
{
    public interface ICardService
    {
        /// <summary>
        /// Card details by userId
        /// </summary>
        /// <param name="userId"></param>
        IEnumerable<CardDTO> GetCardsByUserId(int userId);

        CardDTO GetCardsById(int id);

        /// <summary>
        /// Spending money on this functionality
        /// </summary>
        /// <param name="transactionDTO"></param>
        void MakeCosts(TransactionDTO transactionsDTO, string number = "");

        /// <summary>
        /// Transfer money to another card
        /// </summary>
        /// <param name="transactionDTO"></param>
        /// <param name="number"></param>
       // public void TransferMoneyToCard(TransactionDTO transactionDTO, string number);

        /// <summary>
        /// Receive all transactions by cost or revenue
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="profit"> true - cost, false - revenue</param>
        /// <returns></returns>
        IEnumerable<TransactionDTO> GetTransactionByProfit(int cardId, bool profit);

        /// <summary>
        /// Receive all transactions by type
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="type"> true - cost, false - revenue</param>
        /// <returns></returns>
        IEnumerable<TransactionDTO> GetTransactionByType(int cardId, TransactionTypeDTO type);

        /// <summary>
        /// Receive all transactions
        /// </summary>
        /// <param name="cardId"></param>
        IEnumerable<TransactionDTO> GetAllTransaction(int cardId);
        void Dispose();
    }
}
