using GroceryStoreAPI.Entities;
using GroceryStoreAPI.Services;
using NUnit.Framework;
using System.Linq;

namespace GroceryStore.Tests
{
    public class Tests
    {
        private CustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            _customerService = new CustomerService();
        }

 


        [Test]
        public void DidUpdateTxt()
        {
            var c = new Customer() { id=2,name="Mary"};
            var result = _customerService.Update(c);
            Assert.That(c.name== result.name);
        }

        [Test]
        public void DidUpdateTxt_Fail()
        {
            var c = new Customer() { id = 1, name = "" };
            var result = _customerService.Update(c);
            Assert.Null(result, "You cannot enter blank names.");
        }

        [Test]
        public void DidUpdateTxt_BadId_Fail()
        {
            var c = new Customer() { id = 19, name = "Larry" };
            var result = _customerService.Update(c);
            Assert.Null(result, "Customer must exist.");
        }

        [Test]
        public void DidAddTxt()
        {
            var count = _customerService.Customers.Count();
            var c = new Customer() { id = 0, name = "Gordon" };
            var result = _customerService.Add(c);
            Assert.NotNull(result);
        }

        [Test]
        public void DidAddTxt_Fail()
        {
            var c = new Customer() { id = 0, name = "      " };
            var result = _customerService.Add(c);
            Assert.Null(result, "You cannot enter blank names.");
        }

        [Test]
        public void DidFindCustomer()
        {
       
            var result = _customerService.GetById(3);
            Assert.NotNull(result, "Customer found");
        }


        [Test]
        public void DidFindCustomer_Fail()
        {

            var result = _customerService.GetById(7);
            Assert.Null(result, "Customer must exist");
        }

    }
}