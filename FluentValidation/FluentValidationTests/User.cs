using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTests
{
    public class User
    {
        public User()
        {
            Address = new Address();
        }

        [Display(Name = "Nazwa użytkownika")]
        public string Name { get; set; }

        public string Email { get; set; }

        public bool CreateInvoice { get; set; }

        public string Nip { get; set; }

        public Address Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
