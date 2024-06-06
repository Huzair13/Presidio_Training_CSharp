using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTesting
{
    public class ProductRepositoryDALTest
    {
        IRepository<int, Product> repository;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
        }

        [Test]
        public async Task AddSuccessTest()
        {
            //Arrange 
            Product newProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            }; 
            //Action
            var result = await repository.Add(newProduct);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task AddFailTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            Product newProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            //Action
            var result = await repository.Add(newProduct);
            //Assert
            Assert.AreEqual(result.Id,1);
        }

        [Test]
        public async Task GetAllSuccessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

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
        public async Task GetByKeySuccessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            //Action
            var result = await repository.GetByKey(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public async Task GetByKeyExceptionTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => repository.GetByKey(2));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);

        }

        [Test]
        public async Task DeleteProductSucessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            //Action
            var results = await repository.Delete(1);

            //Assert
            Assert.NotNull(results);
        }

        [Test]
        public async Task DeleteProductExceptionTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => repository.Delete(2));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateCustomerSucessTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            Product updatedProduct = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 11,
                QuantityInHand = 10,
            };

            //Action
            var results = await repository.Update(updatedProduct);

            //Assert
            Assert.AreEqual(results.Price, updatedProduct.Price);

        }

        [Test]
        public async Task UpdateProductExceptionTest()
        {
            //Arrange 
            Product product = new Product()
            {
                Id = 1,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            await repository.Add(product);

            Product updatedProduct = new Product()
            {
                Id = 2,
                Name = "KitKat",
                Price = 10,
                QuantityInHand = 10,
            };
            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGiveIdException>(() => repository.Update(updatedProduct));

            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);

        }

    }
}