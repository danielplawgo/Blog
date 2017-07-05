using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateService.Models
{
    public class User
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}