using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab3.BLL;
using Lab3.BLL.Interfaces;
using Lab4.WebAPI.Models;
using AutoMapper;
using System.Threading;

namespace Lab4.WebAPI.Controllers
{
    public class CardsController : ApiController
    {
        private ICardService _cardService;
        private IUserService _userService;

        public CardsController(ICardService cardServ, IUserService userServ)
        {
            _cardService = cardServ;
            _userService = userServ;
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var card = _cardService.GetCardsById(id);

                if (card != null && id >= 0)
                {
                    var mapper = new MapperConfiguration(conf => conf.CreateMap<CardDTO, CardViewModel>()).CreateMapper();
                    return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<CardDTO, CardViewModel>(card));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Card with id = " + id + " not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Get([FromUri] string login)
        {
            try
            {
                var user = _userService.GetUserByLogin(login);
                var cards = _cardService.GetCardsByUserId(user.Id);

                if (cards != null)
                {
                    var mapper = new MapperConfiguration(conf => conf.CreateMap<CardDTO, CardViewModel>()).CreateMapper();
                    return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<IEnumerable<CardDTO>, IEnumerable<CardViewModel>>(cards));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with login = " + login + " not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage PostMakeTransaction([FromBody]TransactionViewModel transactionsViewModel, [FromUri] string number)
        {
            try
            {
                var s = new TransactionDTO()
                {
                    CardId = transactionsViewModel.CardId,
                    Sum = transactionsViewModel.Sum,
                    Type = (TransactionTypeDTO)transactionsViewModel.Type
                };

                _cardService.MakeCosts(s, number);
                // var mapper = new MapperConfiguration(conf => conf.CreateMap<TransactionDTO, TransactionViewModel>()).CreateMapper();
                var message = Request.CreateResponse(HttpStatusCode.Created, transactionsViewModel);
                message.Headers.Location = new Uri(Request.RequestUri + transactionsViewModel.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        //public IEnumerable<CardViewModel> MappingCard(IEnumerable<CardViewModel>)
        //{
        //    Mapper.
        //}
        // [BasicAuthentication]
        //public HttpResponseMessage Get(int userId)
        //{
        //string username = Thread.CurrentPrincipal.Identity.Name;
        //    try
        //    {
        //        IEnumerable<CardDTO> data = cardService.GetCardsByUserId(userId);

        //        var mapper = new MapperConfiguration(conf => conf.CreateMap<CardDTO, CardViewModel>()).CreateMapper();

        //        return mapper.Map<IEnumerable<CardDTO>, List<CardViewModel>>(data);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //        return null;
        //    }
        //}

        //[HttpGet("{}/{}")]
        //public HttpResponseMessage GetTransactionsBy(string property = "All")
        //{
        //    var cardTrans = cardService.GetAllTransaction();
        //}
    }
}
