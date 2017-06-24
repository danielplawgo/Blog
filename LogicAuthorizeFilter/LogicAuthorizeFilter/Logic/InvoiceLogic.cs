using LogicAuthorizeFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicAuthorizeFilter.Logic
{
    public class InvoiceLogic : IInvoiceLogic
    {
        private ApplicationDbContext _db;

        public InvoiceLogic(ApplicationDbContext db)
        {
            _db = db;
        }

        public Invoice GetById(int id)
        {
            return _db.Invoices.FirstOrDefault(i => i.Id == id);
        }

        public bool HasAccess(ApplicationUser user, Invoice entity)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }

            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if(entity.UserId == user.Id)
            {
                return true;
            }

            if (user.IsAdmin)
            {
                return true;
            }

            return false;
        }

        public bool HasAccess(ApplicationUser user, int id)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var entity = GetById(id);

            if (entity == null)
            {
                return false;
            }

            return HasAccess(user, entity);
        }
    }

    public interface IInvoiceLogic : IAuthorizeLogic<Invoice>
    {
    }
}