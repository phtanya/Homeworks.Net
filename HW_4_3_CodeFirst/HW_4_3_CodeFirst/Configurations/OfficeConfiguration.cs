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
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x => x.OfficeId);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Location).HasMaxLength(100);
        }
    }
}
