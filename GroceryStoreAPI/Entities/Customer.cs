using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Entities
{
    public class Customers
    {
        public List<Customer> customers { get; set; }
    }
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
