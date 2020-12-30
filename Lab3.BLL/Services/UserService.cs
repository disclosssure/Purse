using Lab3.BLL.Interfaces;
using Lab3.DAL;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.BLL.Infrastructure;

namespace Lab3.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork iow)
        {
            Database = iow;
        }

     
        public UserDTO GetUserById(int id)
        {
            if (id <= 0) throw new ArgumentException("This id doesn't exist");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<User, UserDTO>()
                                                             .ForMember(x => x.FullName, x => x.MapFrom(m => m.Name + " " + m.Surname)))
                                                             .CreateMapper();
            var user = Database.Users.Get(id);
            if (user == null)
                throw new ValidationException("User not found", "User");

            return mapper.Map<User, UserDTO>(user);
        }

        UserDTO IUserService.GetUserByLogin(string login)
        {
            if (login == null) throw new ArgumentNullException("Login = null");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<User, UserDTO>()
                                                             .ForMember(x => x.FullName, x => x.MapFrom(m => m.Name + " " + m.Surname)))
                                                             .CreateMapper();
            var user = Database.Users.SingleOrDefault(x => x.Login == login);
            if (user == null)
                throw new ValidationException("User not found", "User");

            return mapper.Map<User, UserDTO>(user);
        }

        public UserDTO LogIn(string login, string password)
        {
            if (login == null || password == null)
                new ArgumentNullException("Null as login or password");

            var mapper = new MapperConfiguration(conf => conf.CreateMap<User, UserDTO>()
                                                 .ForMember(x => x.FullName, x => x.MapFrom(m => m.Name + " " + m.Surname)))
                                                 .CreateMapper();
            var user = Database.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
                throw new ValidationException("User not found. Incorrect login or password", "User");
            return mapper.Map<User, UserDTO>(user);
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
