using HW_4_3_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3_CodeFirst.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectId);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Budget).HasColumnType("money");
            builder.Property(x => x.StartedDate).HasColumnType("date");
            builder.HasOne(x => x.Client).WithMany(x => x.Project).HasForeignKey(x => x.ClientId);
            builder.HasData(
                new Project
                {
                    ProjectId = 1,
                    Name = "Project1",
                    Budget = 10000,
                    StartedDate= new DateTime(2022, 12, 7),
                    ClientId = 1
                },
                new Project
                {
                    ProjectId = 2,
                    Name = "Project2",
                    Budget = 20000,
                    StartedDate = new DateTime(2023, 1, 7),
                    ClientId = 2
                },
                new Project
                {
                    ProjectId = 3,
                    Name = "Project3",
                    Budget = 30000,
                    StartedDate = new DateTime(2023, 1, 7),
                    ClientId = 3
                },
                new Project
                {
                    ProjectId = 4,
                    Name = "Project4",
                    Budget = 40000,
                    StartedDate = new DateTime(2023, 1, 7),
                    ClientId = 4
                },
                new Project
                {
                    ProjectId = 5,
                    Name = "Project5",
                    Budget = 50000,
                    StartedDate = new DateTime(2023, 1, 7),
                    ClientId = 5
                }
                );
        }
    }
}

