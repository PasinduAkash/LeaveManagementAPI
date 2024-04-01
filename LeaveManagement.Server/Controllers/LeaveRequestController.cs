using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeveRequests.Requests.Commands;
using LeaveManagement.Application.Features.LeveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDTO>>> Get()
        {
            var response = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(response);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var response = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id  });
            return Ok(response);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateLeaveRequestDTO leaveRequestDTO)
        {
            var response = await _mediator.Send(new CreateLeaveRequestCommand { LeaveRequestDTO = leaveRequestDTO});
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut]
        public async Task<IActionResult> Put(int Id, [FromBody] UpdateLeaveRequestDTO leaveRequestDTO )
        {
            Console.WriteLine("Put method was hit");
            await _mediator.Send(new UpdateLeaveRequestCommand { Id = Id, LeaveRequestDTO = leaveRequestDTO });
            return NoContent();
        }

        // PUT api/<LeaveRequestController>/true
        [HttpPut("/changeapproval")]
        public async Task<ActionResult> Put(int Id, [FromBody] ChangeLeaveRequestApprovalDTO ChangeleaveRequestDTO)
        {
            var response = await _mediator.Send(new UpdateLeaveRequestCommand { Id = Id, ChangeLeaveRequestApprovalDTO = ChangeleaveRequestDTO });
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
