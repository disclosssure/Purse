using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public class UserRepositories : Repository<User>, IUserRepositories
    {
        public UserRepositories(MyDbContext myDbContext)
            : base(myDbContext)
        {

        }
    }
}
