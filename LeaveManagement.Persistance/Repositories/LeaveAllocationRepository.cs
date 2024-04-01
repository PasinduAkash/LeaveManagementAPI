using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository: GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
