using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Application.Validation
{
    public class ProductNameValidator : ValidationAttribute
    {
        public ProductNameValidator(string? message)
        {
            ErrorMessage = message;
        }

        public override bool IsValid(object? value)
        {

            if ( value is null || string.IsNullOrWhiteSpace((string?)value))
            {
                return false;
            }
                

            if (value.ToString().Count() == 1)
            {
                return false;
            }

            return true;
        }

    }
}
