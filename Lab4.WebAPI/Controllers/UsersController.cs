using Lab3.BLL.Interfaces;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab4.WebAPI.Models;
using Lab3.BLL;

namespace Lab4.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService;


        public UsersController(IUserService userServ)
        {
            _userService = userServ;
        }

        [BasicAuthentication]
        public HttpResponseMessage Get(int id)
        {
            var user = _userService.GetUserById(id);

            if (user != null)
            {
                var mapper = new MapperConfiguration(conf => conf.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
                return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<UserDTO, UserViewModel>(user));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with Id = " + id.ToString() + " not found");
            }

        }

        [BasicAuthentication]
        public HttpResponseMessage Get([FromUri]string login)
        {
            try
            {
                var user = _userService.GetUserByLogin(login);

                if (user != null)
                {
                    var mapper = new MapperConfiguration(conf => conf.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
                    return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<UserDTO, UserViewModel>(user));
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
    }
}
