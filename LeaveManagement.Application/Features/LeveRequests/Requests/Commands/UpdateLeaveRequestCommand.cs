using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDTO LeaveRequestDTO { get; set; }
        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDTO { get; set;}
    }
}
