using AutoMapper;
using Lab3.BLL;
using Lab3.BLL.Interfaces;
using Lab4.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab4.WebAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        private ICardService _cardService;

        public TransactionsController(ICardService cardServ)
        {
            _cardService = cardServ;
        }

        public HttpResponseMessage Get(int Id)
        {
            try
            {
                var transactions = _cardService.GetAllTransaction(Id);

                if (transactions != null)
                {
                    var mapper = new MapperConfiguration(conf => conf.CreateMap<TransactionDTO, TransactionViewModel>()).CreateMapper();
                    return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<IEnumerable<TransactionDTO>, IEnumerable<TransactionViewModel>>(transactions));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Transactions for user with id = " + Id + " not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage GetByType([FromUri] int cardId, [FromUri] int type)
        {
            try
            {
                var transactions = _cardService.GetTransactionByType(cardId, (TransactionTypeDTO)type);

                if (transactions != null)
                {
                    var mapper = new MapperConfiguration(conf => conf.CreateMap<TransactionDTO, TransactionViewModel>()).CreateMapper();
                    return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<IEnumerable<TransactionDTO>, IEnumerable<TransactionViewModel>>(transactions));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Transactions for user with id = " + cardId + " not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
