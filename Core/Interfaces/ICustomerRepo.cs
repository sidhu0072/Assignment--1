using Core.Models;

namespace Core.Interfaces
{
    public interface ICustomerRepo
    {
        List<Customer> GetAllCustomers();
    }
}