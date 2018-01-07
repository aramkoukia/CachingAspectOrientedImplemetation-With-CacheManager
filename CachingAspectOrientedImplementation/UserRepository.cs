using System.Collections.Generic;

namespace CachingAspectOrientedImplemetation
{
    public class UserRepository : IUserRepository
    {
        [Cache("key")]
        public IEnumerable<string> GetUsers()
        {
            return new string[] { "User 1", "User 2" };
        }

        public string GetUsers(string id)
        {
            return "User 1";
        }

        [InvalidateCache("key")]
        public bool UpdateUser(string username)
        {
            return true;
        }
    }
}