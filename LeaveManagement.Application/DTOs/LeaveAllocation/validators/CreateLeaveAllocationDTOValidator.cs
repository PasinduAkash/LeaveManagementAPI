using LeaveManagement.Application.Contracts.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.validators
{
    public class CreateLeaveAllocationDTOValidator : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));
        }
    }
}
