using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).Must(Containat).WithMessage("Invalid Email address");
        }

        private bool Containat(string arg)
        {
            return arg.Contains("@");
        }
    }
}
