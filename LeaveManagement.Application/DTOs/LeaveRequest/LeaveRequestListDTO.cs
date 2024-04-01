using LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDTO
    {
        public LeaveRequestDTO LeaveRequest { get; set; }
        public bool DateRequested { get; set; }
        public bool? Approved { get; set; }


    }
}
