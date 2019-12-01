using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Vidley.Models;

namespace Vidley.Models
{
    public class Min18YearsForMembership  : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId ==MemberShipType.PayasYouGo  
                || customer.MemberShipTypeId==MemberShipType.Unknown)
            {
                return ValidationResult.Success;
            }
            if (customer.Dob == null)
            {
                return new ValidationResult("Birth date is required");
            }
            var age = DateTime.Today.Year - customer.Dob.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be  18 years old to go on a membership");
        }
    }
}