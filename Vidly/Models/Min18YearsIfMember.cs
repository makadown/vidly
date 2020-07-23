using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Se requiere fecha de Nacimiento");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18 ) ? ValidationResult.Success : 
                        new ValidationResult("Cliente debe tener al menos 18 años para una membresía");
        }
    }
}