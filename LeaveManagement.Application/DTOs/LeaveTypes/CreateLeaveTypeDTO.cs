using LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeaveManagement.Application.DTOs.LeaveTypes
{
    public class CreateLeaveTypeDTO : ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
