using LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveRequestDTO LeaveRequest { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime? DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

    }
}
