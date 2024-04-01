using LeaveManagement.Application.Contracts.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.validators
{
    public class ILeaveAllocationDTOValidator : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDTOValidator(ILeaveTypeRepository IleaveTypeRepository)
        {
            _leaveTypeRepository = IleaveTypeRepository; 
            RuleFor(p => p.NumberOfDays)
                    .GreaterThan(0).WithMessage("{PropertyName} should not exceed {ComparisonValue} characters");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} should atleast be 1");

             RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return leaveTypeExists;
                })
                .WithMessage("{PropertyName} does not exist");
        }
    }
}
