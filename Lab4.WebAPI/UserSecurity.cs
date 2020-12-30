using Lab3.BLL.Interfaces;
using Lab3.BLL.Services;
using Lab3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.WebAPI
{
    public class UserSecurity
    {
        public static IUserService _userService;

        public UserSecurity(IUserService userService)
        {
            _userService = userService;
        }

        public static bool Login(string username, string password)
        {
            try
            {
                _userService = new UserService(new UnitOfWork(new MyDbContext()));
                var user = _userService.LogIn(username, password);

                if (user != null)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}