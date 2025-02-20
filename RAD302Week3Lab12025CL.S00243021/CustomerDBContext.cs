using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025CL.S00243021
{
    public class CustomerDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ActivityAPIClient.Track(StudentID: "s00243021", StudentName: "Dmytro Severin",
activityName: "Rad302 Week 3 Lab 1", Task: "Creating Customer DB Schema");

            var myconnectionstring = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = CustomerCoreDB";
            optionsBuilder.UseSqlServer(myconnectionstring)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ActivityAPIClient.Track(
                StudentID: "s00243021",
                StudentName: "Dmytro Severin",
                activityName: "Rad302 Week 3 Lab 1",
                Task: "Seeding Customer Data"
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    ID = 1,
                    Name = "Patricia McKenna",
                    Address = "8 Johnstown Road, Cork",
                    CreditRating = 200.00f
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
