using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistance.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {

      public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                 new LeaveType
                 {
                     Id = 1,
                     DefaultDays = 10,
                     Name = "Vacation",
                     CreatedBy = "PK",
                     LastModifiedBy = "PK",
                     DateCreated = DateTime.Now,
                     LastModifiedDate = DateTime.Now,

                 },

                 new LeaveType
                 {
                     Id = 2,
                     DefaultDays = 12,
                     Name = "Sick",
                     CreatedBy = "PK",
                     LastModifiedBy = "PK",
                     DateCreated = DateTime.Now,
                     LastModifiedDate = DateTime.Now,
                 }
                 );
        }

    }
}
