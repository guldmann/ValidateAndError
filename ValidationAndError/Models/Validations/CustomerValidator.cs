using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ValidationAndError.Models.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>, IValidatorInterceptor
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Surname)
                .NotNull()
                .Must(IsValidName)
                .WithMessage("{PropertyName} should be not empty. NEVER!");

            RuleFor(customer => customer.Age)
                .GreaterThan(1)
                .WithMessage("{PropertyName} need to be greater then 1");

            RuleFor(c => c.Email).EmailAddress()
                .NotNull()
                .WithMessage("{Email} is wrong format");
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }

        public IValidationContext BeforeMvcValidation(ControllerContext controllerContext, IValidationContext commonContext)
        {
            if (commonContext.InstanceToValidate is Customer instance)
            {
                this.ValidateAndThrow(instance);
            }

            return commonContext;
        }

        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, IValidationContext commonContext, ValidationResult result)
        {
            return result;
        }
    }
}