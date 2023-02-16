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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId);
            builder.Property(x => x.CompanyName).HasMaxLength(50);
            builder.Property(x => x.Location).HasMaxLength(50);
            builder.Property(x => x.FoundedDate).HasColumnType("date");
            builder.Property(x => x.Email).HasColumnType("nvarchar(320)");
            builder.HasMany(x => x.Project).WithOne(x => x.Client).HasForeignKey(x => x.ClientId);
            builder.HasData(
                new Client
                {
                    ClientId = 1,
                    CompanyName = "Company-A",
                    Location = "Kyiv",
                    FoundedDate = new DateTime(2021, 12, 7),
                    Email = "copmpany-a@gmail.com"
                },
                new Client
                {
                    ClientId = 2,
                    CompanyName = "Company-B",
                    Location = "Kharkiv",
                    FoundedDate = new DateTime(2022, 3, 17),
                    Email = "company-b@gmail.com"
                },
                new Client
                {
                    ClientId = 3,
                    CompanyName = "Company-C",
                    Location = "Lviv",
                    FoundedDate = new DateTime(2013, 5, 19),
                    Email = "company-c@gmail.com"
                },
                new Client
                {
                    ClientId = 4,
                    CompanyName = "Company-D",
                    Location = "Madrid",
                    FoundedDate = new DateTime(2017, 3, 14),
                    Email = "company-d@gmail.com"
                },
                new Client
                {
                    ClientId = 5,
                    CompanyName = "Company-E",
                    Location = "London",
                    FoundedDate = new DateTime(2020, 8, 24),
                    Email = "company-e@gmail.com"
                }
            );
        }
    }
}
