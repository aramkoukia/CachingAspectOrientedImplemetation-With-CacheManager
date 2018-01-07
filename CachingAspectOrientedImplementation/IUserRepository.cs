using System.Collections.Generic;

namespace CachingAspectOrientedImplemetation
{
    public interface IUserRepository
    {
        [Cache("key")]
        IEnumerable<string> GetUsers();

        string GetUsers(string id);

        [InvalidateCache("key")]
        bool UpdateUser(string username);
    }
}