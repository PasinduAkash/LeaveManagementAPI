using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.DTOs.LeaveTypes;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<LeaveTypeDTO>> Get()
        {
            var response = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(response);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(int id)
        {
            var response = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id});
            return Ok(response);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDTO leaveAllocationDTO)
        {
            var response = await _mediator.Send(new CreateLeaveAllocationCommand { LeaveAllocationDTO = leaveAllocationDTO });
            return Ok(response);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDTO leaveAllocationDTO)
        {
            await _mediator.Send(new UpdateLeaveAllocationCommand {  LeaveAllocationDTO = leaveAllocationDTO });
            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}
