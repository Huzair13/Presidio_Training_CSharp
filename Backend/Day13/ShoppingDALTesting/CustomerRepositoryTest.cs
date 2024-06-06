using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTesting
{
    public class CustomerRepositoryTest
    {
        IRepository<int, Customer> repository;

        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
        }

        [Test]
        public async Task AddSuccessTestAsync()
        {
            // Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };

            // Action
            var result = await repository.Add(customer);

            // Assert
            Assert.AreEqual(100, result.Id);
        }

        [Test]
        public async Task AddFailTestAsync()
        {
            // Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            // Action
            Customer newCustomer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            var result = await repository.Add(newCustomer);

            // Assert
            Assert.AreEqual(result.Id, 100);
        }

        [Test]
        public async Task GetAllSuccessTestAsync()
        {
            // Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            // Action
            var result = await repository.GetAll();

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task GetAllFailureTestAsync()
        {
            // Action
            var result = await repository.GetAll();

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public async Task GetByKeySuccessTestAsync()
        {
            // Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            // Action
            var result = await repository.GetByKey(100);

            // Assert
            Assert.AreEqual(result.Id, 100);
        }

        [Test]
        public async Task GetByKeyExceptionTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            //Action
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() =>  repository.GetByKey(2));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);

        }

        [Test]
        public async Task DeleteCustomerSucessTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            //Action
            var results =await repository.Delete(100);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public async Task DeleteCustomerExceptionTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            //Action
            var exception =  Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateCustomerSucessTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            Customer updatedCustomer = new Customer()
            {
                Id = 100,
                Age = 22,
                Phone = "9977881857"
            };

            //Action
            var results=await repository.Update(updatedCustomer);

            //Assert
            Assert.AreEqual(results.Age, updatedCustomer.Age);

        }

        [Test]
        public async Task UpdateCustomerExceptionTest()
        {
            //Arrange 
            Customer customer = new Customer()
            {
                Id = 100,
                Age = 20,
                Phone = "9677381857"
            };
            await repository.Add(customer);

            Customer updatedCustomer = new Customer()
            {
                Id = 101,
                Age = 22,
                Phone = "9977881857"
            };

            //Action
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => repository.Update(updatedCustomer));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);

        }

    }
}
