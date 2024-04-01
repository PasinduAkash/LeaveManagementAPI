
using LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;
using System.Collections.Generic;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
    {

    }
}
