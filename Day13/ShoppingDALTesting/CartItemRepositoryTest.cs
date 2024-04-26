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
    public class CartItemRepositoryTest
    {
        IRepository<int, CartItem> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartItemRepository();
        }

        [Test]
        public async Task AddSuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };

            //Action
            var result = await repository.Add(cartItem);
            //Assert
            Assert.AreEqual(1, result.CartId);
        }

        [Test]
        public async Task AddFailureTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);
            CartItem newCartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };

            //Action
            var result = await repository.Add(newCartItem);
            //Assert
            Assert.AreEqual(result.CartId, 1);
        }

        [Test]
        public async Task GetAllSuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

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
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            var results = await repository.Delete(10);
            Assert.NotNull(results);
        }

        [Test]
        public async Task CartItemDeleteFailureTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            //Action
            var exception = Assert.ThrowsAsync<NoCartItemFoundExeption>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);
        }


        [Test]
        public async Task GetByKeySuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            //Action
            var result = await repository.GetByKey(10);

            //Assert
            Assert.AreEqual(result.CartId, 1);
        }

        [Test]
        public async Task GetByKeyExceptionTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            //Action
            var exception = Assert.ThrowsAsync<NoCartItemFoundExeption>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);

        }

        [Test]
        public async Task DeleteCartSucessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            //Action
            var results = await repository.Delete(10);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public async Task DeleteCartExceptionTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            //Action
            var exception = Assert.ThrowsAsync<NoCartItemFoundExeption>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);
        }

        [Test]
        public async Task UpdateCartSucessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);

            //Arrange 
            CartItem newCartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 299,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };


            //Action
            var results = await repository.Update(newCartItem);

            //Assert
            Assert.AreEqual(results.Price, newCartItem.Price);

        }

        [Test]
        public async Task UpdateCartExceptionTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 100,
                ProductId = 10,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 1,
                Quantity = 3
            };
            await repository.Add(cartItem);


            //Arrange 
            CartItem newCartItem = new CartItem()
            {
                Product = new Product() { },
                Price = 1200,
                ProductId = 19,
                Discount = 0,
                PriceExpiryDate = DateTime.Now.AddDays(7),
                CartId = 12,
                Quantity = 3
            };
            //Action
            var exception = Assert.ThrowsAsync<NoCartItemFoundExeption>(() => repository.Update(newCartItem));

            //Assert
            Assert.AreEqual("No Cart Item Found with the given ID", exception.Message);

        }
    }
}
