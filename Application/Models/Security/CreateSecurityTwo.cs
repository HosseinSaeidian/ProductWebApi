using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Application.Models.Security
{
    public class CreateSecurityTwo : IValidatableObject 
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var resault = new List<ValidationResult>();


            if (string.IsNullOrWhiteSpace(UserName))
            {
                resault.Add(new ValidationResult("username is problem" , new[] { "UserName" }));
            }

            return resault;
        }
    }
}