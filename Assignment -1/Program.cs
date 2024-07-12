using Core.Interfaces;
using Core.Services;
using Core.Models;

namespace CustomerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICustomerRepo, CustomerRepo>();
            builder.Services.AddSingleton<ICustomerService, CustomerService>();

            var app = builder.Build();

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


    public class CustomerRepo : ICustomerRepo
    {
        private readonly List<Customer> _customers;

        public CustomerRepo()
        {

            _customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Gurvinder", LastName = "Singh" },
                new Customer { Id = 2, FirstName = "Navjot", LastName = "Kaur" },
                new Customer { Id = 3, FirstName = "Balkar", LastName = "Singh" }
            };
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}
