using LeaveManagement.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int Id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        public Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
