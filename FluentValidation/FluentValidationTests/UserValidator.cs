using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTests
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IUserLogic userLogic)
        {
            RuleFor(u => u.Name)
                .NotEmpty();

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage(UserResources.EmailIsRequiredError);

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email ma niepoprawny format");

            When(u => u.CreateInvoice, () =>
            {
                RuleFor(u => u.Nip)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .WithMessage("Nip jest wymagany")
                    .Must(nip => IsNipValid(nip))
                    .WithMessage("Nip ma niepoprawny format") ;
            });
                     
            RuleFor(u => u.Email)
                .Must(email => userLogic.Exist(email))
                .WithMessage(u => string.Format("Użytkownik o adresie {0} już istnieje.", u.Email));

            RuleFor(u => u.Address)
                .SetValidator(new AddressValidator());

            RuleFor(u => u.Orders)
                    .SetCollectionValidator(new OrderValidator());
        }

        private bool IsNipValid(string nip)
        {
            if (nip == null)
            {
                return false;
            }

            if (nip.Length != 10)
            {
                return false;
            }

            return true;
        }
    }
}
