using GroceryStoreAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer Add(Customer C);
        Customer GetById(int Id);
        Customer Update(Customer C);
    }
}
