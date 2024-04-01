using LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDTO : BaseDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public int LeaveTypeId { get; set; }
   
        public string RequestComments { get; set; }
       
        public bool Cancelled { get; set; }
    }
}
