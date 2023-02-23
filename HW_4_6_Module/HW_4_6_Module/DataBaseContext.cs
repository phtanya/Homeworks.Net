using HW_4_6_Module.Configurations;
using HW_4_6_Module.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Module
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }

        private string _connectionString;

        public DataBaseContext(string connectionString = "Data Source=GENZEL\\SQLEXPRESS;Initial Catalog=HW_4_6_Module;Integrated Security=true")
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = configBuilder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBase")).UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new SongArtistConfiguration());
        }
    }
}
