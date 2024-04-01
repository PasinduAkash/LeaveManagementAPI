using AutoMapper;
using LeaveManagement.Application.Features.LeveRequests.Requests.Queries;
using LeaveManagement.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using LeaveManagement.Application.DTOs.LeaveRequest;

namespace LeaveManagement.Application.Features.LeveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveRequestRepository.Get(request.Id);
            return _mapper.Map<LeaveRequestDTO>(leaveAllocation);

        }
    }
}
