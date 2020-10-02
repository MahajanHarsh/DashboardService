using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public interface IDataManager
    {
        List<User> GetUsers();
        bool AddUser(User user);

    }
}
