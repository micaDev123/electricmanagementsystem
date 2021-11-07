using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERMSAPI.Models;
using ERMSAPI.DBContext;
namespace ERMSAPI.Services
{
    public interface IUserService
    {
        IEnumerable<Users> getAllUsers();
        Users getUserByUsername(string username);
        Users createUser(Users user);
        void updateUser(Users user);
        void deleteUser(string username);
    }
    public class UserService : IUserService
    {
        private readonly ERMSContext _context;
        public UserService(ERMSContext context)
        {
            _context = context;
        }
        public IEnumerable<Users> getAllUsers()
        {
            return _context.Users;
        }
        public Users getUserByUsername(string username)
        {
            return _context.Users.Find(username);
        }
        public Users createUser(Users user)
        {
            if (_context.Users.Any(x => x.username == user.username))
                throw new Exception("Username \"" + user.username + "\" is already taken");
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void updateUser(Users userParam)
        {
            var user = _context.Users.Find(userParam.username);

            if (user == null)
                throw new Exception("User not found");

            // update user properties
            user.name = userParam.name;  

            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void deleteUser(string username)
        {
            var user = _context.Users.Find(username);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        } 
    }
}
