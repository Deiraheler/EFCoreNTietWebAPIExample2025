
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RAD302Week3Lab12025CL.S00243021;
using RAD302Week3Lab12025WebAPI.S00243021.DataLayer;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025WebAPI.S00243021
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddDbContext<CustomerDBContext>();
            builder.Services.AddTransient<ICustomer<Customer>, CustomerRepository>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Week4ConnectionString"));
            });


            ActivityAPIClient.Track(StudentID: "S00243021", StudentName: "Dmytro Severin", activityName: "Rad302 Week 4 2025 Lab 1", Task: "Implementing Authentication Context Model");


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
