using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using LeaveManagement.Application.DTOs.LeaveTypes.Validators;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeveRequests.Requests.Commands;
using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Application.Responses;
using LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LeaveManagement.Application.Contracts.Infrastructure;
using LeaveManagement.Application.Models;

namespace LeaveManagement.Application.Features.LeveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

              
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;

            var email = new Email()
            {
                To = "pasindukulasinghe123@gmail.com",
                Subject = "Leave Request Submitted",
                Body = $"Your leave request for {request.LeaveRequestDTO.StartDate:D} to {request.LeaveRequestDTO.EndDate:D} has been submitted successfully"
            };

            try
            {

                await _emailSender.SendEmail(email);
               

            } catch (Exception ex)
            {
                //Log of handle error do not throw
               
              
             
            }

            return response;
        }
    }
}
