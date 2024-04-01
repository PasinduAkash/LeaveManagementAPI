using AutoMapper;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using LeaveManagement.Application.DTOs.LeaveAllocation;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDTO>
    {


        private readonly ILeaveAllocationRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);

        }


    }
}
