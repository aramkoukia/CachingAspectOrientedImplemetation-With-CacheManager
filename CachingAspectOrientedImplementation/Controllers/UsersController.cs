using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CachingAspectOrientedImplemetation.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return _userRepository.GetUsers();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _userRepository.GetUsers(id.ToString());
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            _userRepository.UpdateUser(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
