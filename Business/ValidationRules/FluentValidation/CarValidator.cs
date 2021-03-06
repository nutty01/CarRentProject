﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {

        public CarValidator()
        {

            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Car description must be at least 2 characters");
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).GreaterThan(0);

        }
    }
}
