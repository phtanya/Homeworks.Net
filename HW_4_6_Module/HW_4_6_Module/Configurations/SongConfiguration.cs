using HW_4_6_Module.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Module.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Duration).HasColumnType("decimal(3,2)");
            builder.Property(x => x.ReleasedDate).HasColumnType("date");
            builder.HasOne(x => x.Genre).WithMany(s => s.Song).HasForeignKey(x => x.GenreId);
            builder.HasData(
                new Song
                {
                    Id = 1,
                    Title = "Song1",
                    Duration = 3.22m,
                    ReleasedDate = new DateTime(2022, 11, 11),
                    GenreId = 1
                },
                new Song
                {
                    Id = 2,
                    Title = "Song2",
                    Duration = 2.53m,
                    ReleasedDate = new DateTime(2002, 2, 12),
                    GenreId = 2
                },
                new Song
                {
                    Id = 3,
                    Title = "Song3",
                    Duration = 2.02m,
                    ReleasedDate = new DateTime(1959, 6, 3),
                    GenreId = 3
                },
                new Song
                {
                    Id = 4,
                    Title = "Song4",
                    Duration = 3.22m,
                    ReleasedDate = new DateTime(1872, 9, 30)
                },
                new Song
                {
                    Id = 5,
                    Title = "Song5",
                    Duration = 4.11m,
                    ReleasedDate = new DateTime(2010, 3, 8),
                    GenreId = 5
                });
        }
    }
}
