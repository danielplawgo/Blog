using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTests
{
    public static class IRuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> Nip<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new NipValidator());
        }
    }
}
