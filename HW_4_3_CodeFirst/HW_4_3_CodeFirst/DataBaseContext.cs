using HW_4_3_CodeFirst.Configurations;
using Microsoft.Extensions.Configuration;
using HW_4_3_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3_CodeFirst
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Client> Client { get; set; }

        private string _connectionString;

        public DataBaseContext(string connectionString = "Data Source=GENZEL\\SQLEXPRESS;Initial Catalog=HW_4_3;Integrated Security=true")
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = configBuilder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBase"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
