using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicAuthorizeFilter.Models;

namespace LogicAuthorizeFilter.Logic
{
    public class UserLogic : IUserLogic
    {
        private ApplicationDbContext _db;

        public UserLogic(ApplicationDbContext db)
        {
            _db = db;
        }

        public ApplicationUser GetByName(string name)
        {
            return _db.Users.FirstOrDefault(u => u.UserName == name);
        }
    }
}