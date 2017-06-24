using LogicAuthorizeFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAuthorizeFilter.Logic
{
    public interface IAuthorizeLogic<T> : IAuthorizeLogic where T : BaseEntity
    {
        T GetById(int id);

        bool HasAccess(ApplicationUser user, T entity);
    }

    public interface IAuthorizeLogic
    {
        bool HasAccess(ApplicationUser user, int id);
    }
}
