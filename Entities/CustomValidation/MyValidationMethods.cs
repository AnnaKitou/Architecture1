using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CustomValidation
{
    public class MyValidationMethods
    {
        public static ValidationResult ValidateRange0_150(int value , ValidationContext context)
        {
            bool isValid = true;
            if (value > 150 || value < 0)
            {
                isValid = false;
            }
            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The field {context.MemberName} must be between [0-150]", new List<string> { context.MemberName });
            }
        }


    }
}
