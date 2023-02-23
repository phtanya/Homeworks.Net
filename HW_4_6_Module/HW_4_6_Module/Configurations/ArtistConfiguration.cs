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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
            builder.Property(x => x.DateOfDeath).HasColumnType("date");
            builder.Property(x => x.Phone).HasColumnType("nvarchar(20)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(320)");
            builder.Property(x => x.InstagramUrl).HasColumnType("nvarchar(320)");

                    builder.HasData(
                        new Artist
                        {
                            Id = 1,
                            Name = "Artist1",
                            DateOfBirth = new DateTime(1967, 5, 12),
                            DateOfDeath = new DateTime(2021, 12, 7),
                            Phone = "+380849519323",
                            Email = "email1@gmail.com",
                            InstagramUrl = "instagram.com/artist1"
                        },
                        new Artist
                        {
                            Id = 2,
                            Name = "Artist2",
                            DateOfBirth = new DateTime(1999, 6, 22),
                            Phone = "+38090329002",
                            Email = "email2@gmail.com",
                            InstagramUrl = "instagram.com/artist2"
                        },
                        new Artist
                        {
                            Id = 3,
                            Name = "Artist3",
                            DateOfBirth = new DateTime(1944, 11, 7),
                            DateOfDeath = new DateTime(2021, 8, 23),
                            Phone = "+38084900003",
                            Email = "email3@gmail.com",
                            InstagramUrl = "instagram.com/artist3"
                        },
                        new Artist
                        {
                            Id = 4,
                            Name = "Artist4",
                            DateOfBirth = new DateTime(1983, 2, 21),
                            Phone = "+38084950004",
                            Email = "email4@gmail.com",
                            InstagramUrl = "instagram.com/artist4"
                        },
                        new Artist
                        {
                            Id = 5,
                            Name = "Artist5",
                            DateOfBirth = new DateTime(1972, 9, 12),
                            DateOfDeath = new DateTime(2021, 4, 15),
                            Phone = "+380819510005",
                            Email = "email5@gmail.com",
                            InstagramUrl = "instagram.com/artist5"
                        });
                
        }
    }
}
