using LeaveManagement.Application.Contracts.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDTOValidator: AbstractValidator<ILeaveRequestDTO>
    {
        public ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return leaveTypeExists;

                })
                .WithMessage("{PropertyName} does not exist");

        }
    }
}
