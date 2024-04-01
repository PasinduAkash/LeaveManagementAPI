using LeaveManagement.Application.DTOs.LeaveTypes;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id});
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateLeaveTypeDTO leaveTypeDTO)
        {
            var response = await _mediator.Send(new CreateLeaveTypeCommand { CreateLeaveTypeDTO = leaveTypeDTO});
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDTO leaveTypeDTO)
        {
            await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDTO = leaveTypeDTO });
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return NoContent();
        }
    }
}
