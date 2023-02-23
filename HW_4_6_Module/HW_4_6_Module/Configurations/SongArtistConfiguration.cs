using HW_4_6_Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Module.Configurations
{
    public class SongArtistConfiguration : IEntityTypeConfiguration<SongArtist>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SongArtist> builder)
        {
            builder.HasKey(x => new { x.SongId, x.ArtistId });
            builder.HasOne(sa => sa.Song)
                .WithMany(sa => sa.Artist)
                .HasForeignKey(sa => sa.SongId);
            builder.HasOne(sa => sa.Artist)
                .WithMany(sa => sa.Song)
                .HasForeignKey(sa => sa.ArtistId);
            builder.HasData(new { SongId = 1, ArtistId = 1 },
                        new { SongId = 4, ArtistId = 1 },
                        new { SongId = 2, ArtistId = 2 },
                        new { SongId = 1, ArtistId = 3 },
                        new { SongId = 2, ArtistId = 4 },
                        new { SongId = 3, ArtistId = 5 }
                        );

        }
    }
}
