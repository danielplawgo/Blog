using LogicAuthorizeFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAuthorizeFilter.Logic
{
    public interface IUserLogic
    {
        ApplicationUser GetByName(string name);
    }
}
