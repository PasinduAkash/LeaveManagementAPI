using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveTypes.Validators
{
    public class ILeaveTypeDTOValidator : AbstractValidator<ILeaveTypeDTO>
    {
        public ILeaveTypeDTOValidator() 
        {
            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} should not exceed {ComparisonValue} characters");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} should atleast be 1")
                .LessThan(100).WithMessage("{PropertyName} should be less than 100");


        }
    }
}
