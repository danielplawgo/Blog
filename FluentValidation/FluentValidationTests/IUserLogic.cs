using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTests
{
    public interface IUserLogic
    {
        bool Exist(string email);
    }
}
