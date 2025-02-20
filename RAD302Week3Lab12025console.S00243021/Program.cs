using RAD302Week3Lab12025CL.S00243021;
using System.Reflection;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025console.S00243021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00243021", StudentName: "Dmytro Severin", activityName: "Rad302 Week 3 Lab 1", Task: "Testing Console Queries against the DB Model");

            using (var context = new CustomerDBContext())
            {
                context.Database.EnsureCreated();

                // 1. List all customers with their details.
                Console.WriteLine("All Customers:");
                var allCustomers = context.Customers.ToList();
                foreach (var customer in allCustomers)
                {
                    Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Address: {customer.Address}, Credit Rating: {customer.CreditRating}");
                }

                // 2. List customers with a credit rating greater than 400.
                Console.WriteLine("\nCustomers with Credit Rating > 400:");
                var highCreditCustomers = context.Customers
                                                 .Where(c => c.CreditRating > 400)
                                                 .ToList();
                foreach (var customer in highCreditCustomers)
                {
                    Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Address: {customer.Address}, Credit Rating: {customer.CreditRating}");
                }

                // 3. Insert a new customer with an ID equal to one plus the current maximum ID.
                int maxId = allCustomers.Any() ? allCustomers.Max(c => c.ID) : 0;
                var newCustomer = new Customer
                {
                    ID = maxId + 1,
                    Name = "New Customer",
                    Address = "123 New Street",
                    CreditRating = 350 
                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();

                Console.WriteLine("\nNew Customer Added:");
                Console.WriteLine($"ID: {newCustomer.ID}, Name: {newCustomer.Name}, Address: {newCustomer.Address}, Credit Rating: {newCustomer.CreditRating}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}