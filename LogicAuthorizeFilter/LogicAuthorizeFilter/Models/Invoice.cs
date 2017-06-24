using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicAuthorizeFilter.Models
{
    public class Invoice : BaseEntity
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Number { get; set; }
    }
}