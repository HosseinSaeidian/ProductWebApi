using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Application.Models.Security;

namespace SessionNine.Application.Validation
{
    public class UserNameRuleOne : ValidationAttribute
    {
        public UserNameRuleOne(string message)
        {
            ErrorMessage = message;
        }

        public override bool IsValid(object? value)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()) || value?.ToString().Count() != 10)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
