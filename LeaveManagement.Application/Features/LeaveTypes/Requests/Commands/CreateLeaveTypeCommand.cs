using LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand :IRequest<int>
    {
        public CreateLeaveTypeDTO CreateLeaveTypeDTO { get; set; }
    }
}
