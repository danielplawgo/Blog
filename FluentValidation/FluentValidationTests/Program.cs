using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();

            var user = new User()
                {
                    CreateInvoice = true,
                    Nip = "123",
                    Email = "daniel@plawgo.pl",
                    Orders = new List<Order>()
                    {
                        new Order(){Product = "Laptop"},
                        new Order(){Cost = 14}
                    }
                }
                ;

            var validator = new UserValidator(new UserLogic());

            var validationResult = validator.Validate(user);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine("{0}: {1}", error.PropertyName, error.ErrorMessage);
                }
            }
        }

        static void Initialize()
        {
            ValidatorOptions.ResourceProviderType = typeof(ValidationDefaultErrorsResources);
        }
    }
}
