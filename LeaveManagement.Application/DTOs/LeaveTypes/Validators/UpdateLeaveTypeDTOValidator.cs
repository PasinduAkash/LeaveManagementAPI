using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveTypes.Validators
{
    public class UpdateLeaveTypeDTOValidator : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeDTOValidator() 
        { 
        Include(new ILeaveTypeDTOValidator());

            RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
