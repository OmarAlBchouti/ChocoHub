using AutoMapper;
using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.Repositories;
using ChocolateFactoryManagement.Services.Services;
using Moq;
using static ChocolateFactoryManagement.Domain.AutoMapper.AutoMapperClasses;

namespace ChocolateFactoryManagement.Test
{
    public class FactoryServiceTest
    {
        private readonly IMapper _mapper;
        public FactoryServiceTest()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
        }

        [Fact]
        public async Task Get_All_Factories_Return_Not_Null()
        {
            // Arrange
            var factoryRepositoryMock = new Mock<IFactoryRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();
            factoryRepositoryMock.Setup(x => x.GetAllFactories()).ReturnsAsync(new List<Factory> { new Factory() });
            var factoryService = new FactoryService(factoryRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var result = await factoryService.GetAllAsync();

            // Assert
            Assert.True(result.Any());
        }

        [Fact]
        public async Task Create_Chocolate_Bar_Factory_Exists()
        {
            // Arrange
            var factoryRepositoryMock = new Mock<IFactoryRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var factory = TestObject.GenerateFactoryTest();
            var chocalateBar = TestObject.GenerateChocolateBarTest();

            factoryRepositoryMock.Setup(x => x.GetFactoryById(factory.Id)).ReturnsAsync(factory);
            factoryRepositoryMock.Setup(x => x.UpdateFactory(factory));

            var factoryService = new FactoryService(factoryRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            await factoryService.CreateChocolateBar(factory.Id, chocalateBar);

            // Assert
            Assert.NotNull(chocalateBar);
        }

        [Fact]
        public async Task Create_Chocolate_Bar_Factory_Not_Exists_ThrowsException()
        {
            // Arrange
            var factoryRepositoryMock = new Mock<IFactoryRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var factory = TestObject.GenerateFactoryTest();
            var chocalateBar = TestObject.GenerateChocolateBarTest();

            factoryRepositoryMock.Setup(x => x.GetFactoryById(factory.Id)).ReturnsAsync((Factory)null);
            factoryRepositoryMock.Setup(x => x.UpdateFactory(factory));

            var factoryService = new FactoryService(factoryRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => factoryService.CreateChocolateBar(factory.Id, chocalateBar));

            // Assert
            Assert.True(ex.Result.Message.Equals("The Factory must exist!"));
        }

        [Fact]
        public async Task Delete_Chocolate_Bar_Factory_Exists()
        {
            // Arrange
            var factoryRepositoryMock = new Mock<IFactoryRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var factory = TestObject.GenerateFactoryTest();
            var chocalateBar = TestObject.GenerateChocolateBarTest();

            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBar(factory.Id, chocalateBar.Id)).ReturnsAsync(chocalateBar);
            factoryRepositoryMock.Setup(x => x.DeleteChocolateBarFromFactory(chocalateBar));

            var factoryService = new FactoryService(factoryRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            await factoryService.DeleteChocolateBar(factory.Id, chocalateBar.Id);

            // Assert
            Assert.NotNull(chocalateBar);
        }


        [Fact]
        public async Task Delete_Chocolate_Bar_And_Not_Exists_ThrowsException()
        {
            // Arrange
            var factoryRepositoryMock = new Mock<IFactoryRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var factory = TestObject.GenerateFactoryTest();
            var chocalateBar = TestObject.GenerateChocolateBarTest();

            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync((ChocolateBar)null);
            factoryRepositoryMock.Setup(x => x.DeleteChocolateBarFromFactory(chocalateBar));

            var factoryService = new FactoryService(factoryRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => factoryService.DeleteChocolateBar(factory.Id, chocalateBar.Id));

            // Assert
            Assert.True(ex.Result.Message.Equals("The ChocolateBar must exist!"));
        }

    }

    public static class TestObject
    {
        public static Factory GenerateFactoryTest()
        {
            return new Factory() { Id = 1, Name = "Neuhaus" };
        }

        public static ChocolateBar GenerateChocolateBarTest()
        {
            return new ChocolateBar()
            {
                Id = 1,
                Name = "Purchoco",
                Cacao = "80%",
                Price = 25
            };
        }
    }
}