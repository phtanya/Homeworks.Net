using HW_4_3_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3_CodeFirst.Configurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(x => x.EmployeeProjectId);
            builder.Property(x => x.Rate).HasColumnType("money");
            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeProject);
            builder.HasOne(x => x.Project).WithOne(x => x.EmployeeProject).HasForeignKey<EmployeeProject>(x => x.ProjectId);
            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeProject).HasForeignKey(x => x.EmployeeId);
        }
    }
}
