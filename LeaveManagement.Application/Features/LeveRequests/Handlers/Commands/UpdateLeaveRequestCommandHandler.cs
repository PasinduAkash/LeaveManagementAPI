using AutoMapper;
using LeaveManagement.Application.Features.LeveRequests.Requests.Commands;
using LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using LeaveManagement.Application.Exceptions;

namespace LeaveManagement.Application.Features.LeveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository,  IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
                
            if (request.LeaveRequestDTO != null)
            {

                var validator = new UpdateLeaveRequestDTOValidator(_leaveTypeRepository);
                var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                var leaveRequest = await _leaveRequestRepository.Get(request.Id);
                _mapper.Map(request.LeaveRequestDTO, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }

            else if (request.ChangeLeaveRequestApprovalDTO != null)
            {
                var leaveRequest = await _leaveRequestRepository.Get(request.Id);

                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDTO.Approved);

            }
          
            return Unit.Value;

        }
    }
}
