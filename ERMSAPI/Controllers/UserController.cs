using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERMSAPI.Services;
using ERMSAPI.Models;
namespace ERMSAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _context;
        public UserController(IUserService context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> getAllUsers() {
            var users = _context.getAllUsers();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public ActionResult<Users> getUserByUsername(string username) {
            
            var user = _context.getUserByUsername(username);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<Users> createUser([FromBody] Users user)
        {
            _context.createUser(user);
            var createdUser = _context.getUserByUsername(user.username);
            return Ok(createdUser);
        }

        [HttpPut]
        public ActionResult<Users> getUserByUsername([FromBody] Users user)
        {
            _context.updateUser(user);
            var UpdatedUser = _context.getUserByUsername(user.username);
            return Ok(UpdatedUser);
        }
        // DELETE: api/Users/5
        [HttpDelete("{username}")]
        public void deleteUser(string username) {
            _context.deleteUser(username);
        }
    }
}
    