using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CachingAspectOrientedImplemetation
{
    public interface IUserRepository
    {
        IEnumerable<string> GetUsers();
        string GetUsers(string id);
        bool UpdateUser(string username);
    }
}