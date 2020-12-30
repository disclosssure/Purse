using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO LogIn(string login, string password);

        UserDTO GetUserById(int id);

        UserDTO GetUserByLogin(string login);

        // TODO Registration
        void Dispose();
    }
}
