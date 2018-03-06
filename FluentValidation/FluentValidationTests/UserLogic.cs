using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTests
{
    public class UserLogic : IUserLogic
    {
        public bool Exist(string email)
        {
            if (email == "daniel@plawgo.pl")
            {
                return false;
            }

            return true;
        }
    }
}
