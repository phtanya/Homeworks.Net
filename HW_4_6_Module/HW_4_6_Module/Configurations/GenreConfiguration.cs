using HW_4_6_Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Module.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.HasData(
                new Genre
                {
                    Id = 1,
                    Title = "Pop"
                },
                new Genre
                {
                    Id = 2,
                    Title = "Rock"
                },
                new Genre
                {
                    Id = 3,
                    Title = "Jazz"
                },
                new Genre
                {
                    Id = 4,
                    Title = "Hip-Hop"
                },
                new Genre
                {
                    Id = 5,
                    Title = "Metal"
                });
        }
    }
}
