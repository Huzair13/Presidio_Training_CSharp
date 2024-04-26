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
    public class CartRepositoryTest
    {
        IRepository<int, Cart> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
        }

        [Test]
        public async Task AddSuccessTest()
        {
            //Arrange 
            Cart cart=new Cart() { 
                Id =1,
                CustomerId=10,
                CartItems=new List<CartItem>() { },
                Customer = new Customer() { },
            };

            //Action
            var result = await repository.Add(cart);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task AddFailTest()
        {
            //Arrange 
            Cart cart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };

            await repository.Add(cart);
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };

            //Action
            var result = await repository.Add(newCart);
            //Assert
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public async Task GetAllSuccessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            //Action
            var result = await repository.GetAll();

            //Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task GetAllFailureTest()
        {

            //Action
            var result = await repository.GetAll();

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public async Task CartItemDeleteSuccessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            var results = await repository.Delete(1);
            Assert.NotNull(results);
        }

        [Test]
        public async Task CartItemDeleteFailureTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            //Action
            var exception = Assert.ThrowsAsync<NoCartWithGivenIDException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);
        }


        [Test]
        public async Task GetByKeySuccessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            //Action
            var result = await repository.GetByKey(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public async Task GetByKeyExceptionTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            //Action
            var exception = Assert.ThrowsAsync<NoCartWithGivenIDException>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);

        }

        [Test]
        public async Task DeleteCartSucessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            //Action
            var results = await repository.Delete(1);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public async Task DeleteCartExceptionTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            //Action
            var exception = Assert.ThrowsAsync<NoCartWithGivenIDException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);
        }

        [Test]
        public async Task UpdateCartSucessTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);

            Cart updatedCart = new Cart()
            {
                Id = 1,
                CustomerId = 15,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };


            //Action
            var results = await repository.Update(updatedCart);

            //Assert
            Assert.AreEqual(results.CustomerId, updatedCart.CustomerId);

        }

        [Test]
        public async Task UpdateCartExceptionTest()
        {
            //Arrange 
            Cart newCart = new Cart()
            {
                Id = 1,
                CustomerId = 10,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            await repository.Add(newCart);


            Cart updatedCart = new Cart()
            {
                Id = 2,
                CustomerId = 15,
                CartItems = new List<CartItem>() { },
                Customer = new Customer() { },
            };
            //Action
            var exception = Assert.ThrowsAsync<NoCartWithGivenIDException>(() => repository.Update(updatedCart));

            //Assert
            Assert.AreEqual("No cart with the given ID Found", exception.Message);

        }

    }
}
