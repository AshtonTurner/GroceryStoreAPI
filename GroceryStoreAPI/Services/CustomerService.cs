using GroceryStoreAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public class CustomerService:ICustomer
    {
        private Customers CustomerDatabase ;
        public IEnumerable<Customer> Customers;
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.json");
        public CustomerService()
        {
            try
            {
                string text = File.ReadAllText(path);
                CustomerDatabase = JsonConvert.DeserializeObject<Customers>(text);
                Customers = CustomerDatabase.customers;
            }
            catch 
            {
                //fail safe.
                CustomerDatabase = new Customers();
                CustomerDatabase.customers = new List<Customer>();
            }
        }

        private void PushToDataBase()
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(CustomerDatabase));
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return Customers;
        }

        public Customer Add(Customer C)
        {
            if (C.name.Trim().Length > 0)
            {
                C.id = Customers.Count() + 1;
                Customers.ToList().Add(C);
                PushToDataBase();
                return C;
            }
            return null;
        }

        public Customer GetById(int Id)
        {
            return Customers.FirstOrDefault(x => x.id == Id);
        }

        public Customer Update(Customer C)
        {
            if (C.name.Trim().Length > 0) { 
            var candidate = Customers.First(x => x.id == C.id);
            candidate.name = C.name;
            PushToDataBase();
            return candidate;
        }
            return null;
        }

    }
}
