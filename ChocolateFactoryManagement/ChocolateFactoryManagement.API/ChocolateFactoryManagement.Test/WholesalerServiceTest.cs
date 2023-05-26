using AutoMapper;
using ChocolateFactoryManagement.Domain.DTOs;
using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.Repositories;
using ChocolateFactoryManagement.Services.Services;
using Moq;
using static ChocolateFactoryManagement.Domain.AutoMapper.AutoMapperClasses;

namespace ChocolateFactoryManagement.Test
{
    public class WholesalerServiceTest
    {
        private readonly IMapper _mapper;
        public WholesalerServiceTest()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
        }

        [Fact]
        public async Task Create_Wholesaler_Stock_Chocolate_Bar_And_Not_Exists_ThrowsException()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();

            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync((ChocolateBar)null);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.CreateWholesalerStock(wholesalerStockDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("The ChocolateBar must exist!"));
        }

        [Fact]
        public async Task Create_Wholesaler_Stock_Wholesaler_And_Not_Exists_ThrowsException()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(wholesalerStockDto.WholesalerId)).ReturnsAsync((Wholesaler)null);
            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync(chocalateBar);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.CreateWholesalerStock(wholesalerStockDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("The Wholesaler must exist!"));
        }

        [Fact]
        public async Task Create_Wholesaler_Stock_Valid()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();
            var wholesaler = WholesalerTestObject.GenerateWholesalerTest();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(wholesalerStockDto.WholesalerId)).ReturnsAsync(wholesaler);
            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync(chocalateBar);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            await wholesalerService.CreateWholesalerStock(wholesalerStockDto);

            // Assert
            Assert.NotNull(chocalateBar);
        }


        [Fact]
        public async Task Update_Wholesaler_Stock_Chocolate_Bar_And_Not_Exists_ThrowsException()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            //var wholesalerStock = WholesalerTestObject.GenerateWholesalerStockTest();
            var wholesaler = WholesalerTestObject.GenerateWholesalerTest();
            var stockRequestDto = WholesalerTestObject.GenerateStockRequestDtoTest();

            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync((ChocolateBar)null);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.UpdateWholesalerStock(wholesaler.Id, stockRequestDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("The ChocolateBar must exist!"));
        }

        [Fact]
        public async Task Update_Wholesaler_Stock_Wholesaler_Not_Exists_ThrowsException()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            //var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();
            var wholesaler = WholesalerTestObject.GenerateWholesalerTest();
            var stockRequestDto = WholesalerTestObject.GenerateStockRequestDtoTest();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(wholesaler.Id)).ReturnsAsync((Wholesaler)null);
            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync(chocalateBar);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.UpdateWholesalerStock(wholesaler.Id, stockRequestDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("The Wholesaler must exist!"));
        }

        [Fact]
        public async Task Update_Wholesaler_Stock_Valid()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();
            var wholesaler = WholesalerTestObject.GenerateWholesalerTest();
            var stockRequestDto = WholesalerTestObject.GenerateStockRequestDtoTest();
            var wholesalerStock = WholesalerTestObject.GenerateWholesalerStockTest();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(wholesalerStockDto.WholesalerId)).ReturnsAsync(wholesaler);
            wholesalerRepositoryMock.Setup(x => x.GetWholesalerStock(wholesalerStockDto.WholesalerId, chocalateBar.Id)).ReturnsAsync(wholesalerStock);
            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync(chocalateBar);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            await wholesalerService.UpdateWholesalerStock(wholesaler.Id, stockRequestDto);

            // Assert
            Assert.NotNull(chocalateBar);
        }

        [Fact]
        public void GenerateQuote_EmptyOrder_ThrowsException()
        {
            // Arrange
            var quoteRequestDto = new RequestDto
            {
                ClientName = "Omar",
                WholesalerId = 1,
                ChocolateBars = null
            };

            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.GenerateQuote(quoteRequestDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("The order cannot be empty!"));
        }

        [Fact]
        public void GenerateQuote_DuplicateItems_ThrowsException()
        {
            // Arrange
            var chocolateBars = new List<ChocolateBarRequestDto>(){
                new ChocolateBarRequestDto()
                {
                    Id = 1,
                    Name = "Purchoco",
                    FactoryId = 1,
                    Quantity = 10,
                    Price = 20
                },
                new ChocolateBarRequestDto()
                {
                    Id = 1,
                    Name = "Purchoco",
                    FactoryId = 1,
                    Quantity = 10,
                    Price = 20
                }
            };
            var requestDto = new RequestDto
            {
                ClientName = "Omar",
                WholesalerId = 1,
                ChocolateBars = chocolateBars
            };

            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.GenerateQuote(requestDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("Duplicate items not allowed in the order!"));

        }

        [Fact]
        public void GenerateQuote_Wholesaler_Not_Exists_ThrowsException()
        {
            // Arrange
            var chocolateBars = new List<ChocolateBarRequestDto>(){
                new ChocolateBarRequestDto()
                {
                    Id = 1,
                    Name = "Purchoco",
                    FactoryId = 1,
                    Quantity = 10,
                    Price = 20
                },
                new ChocolateBarRequestDto()
                {
                    Id = 2,
                    Name = "PurchocoDark",
                    FactoryId = 1,
                    Quantity = 10,
                    Price = 20
                }
            };
            var requestDto = new RequestDto
            {
                ClientName = "Omar",
                WholesalerId = 1,
                ChocolateBars = chocolateBars
            };

            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(requestDto.WholesalerId)).ReturnsAsync((Wholesaler)null);

            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.GenerateQuote(requestDto));

            // Assert
            Assert.True(ex.Result.Message.Equals("The wholesaler must exist!"));
        }


        [Fact]
        public void GenerateQuote_Quantity_Over_Stock_ThrowsException()
        {
            // Arrange
            var chocolateBars = new List<ChocolateBarRequestDto>(){
                new ChocolateBarRequestDto()
                {
                    Id = 1,
                    Name = "Purchoco",
                    FactoryId = 1,
                    Quantity = 25,
                    Price = 20
                }
            };
            var requestDto = new RequestDto
            {
                ClientName = "Omar",
                WholesalerId = 1,
                ChocolateBars = chocolateBars
            };
            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();
            var wholesaler = WholesalerTestObject.GenerateWholesalerTest();
            var stockRequestDto = WholesalerTestObject.GenerateStockRequestDtoTest();
            var wholesalerStock = WholesalerTestObject.GenerateWholesalerStockTest();

            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(wholesalerStockDto.WholesalerId)).ReturnsAsync(wholesaler);
            wholesalerRepositoryMock.Setup(x => x.GetWholesalerStock(wholesalerStockDto.WholesalerId, chocalateBar.Id)).ReturnsAsync(wholesalerStock);
            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync(chocalateBar);


            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var ex = Assert.ThrowsAsync<Exception>(() => wholesalerService.GenerateQuote(requestDto));

            // Assert
            Assert.True(ex.Result.Message.Equals($"Quantity of chocolate bar {chocalateBar.Name} in order is greater than the wholesaler's stock"));
        }

        [Fact]
        public async Task GenerateQuote_Valid()
        {
            // Arrange
            var chocolateBars = new List<ChocolateBarRequestDto>(){
                new ChocolateBarRequestDto()
                {
                    Id = 1,
                    Name = "Purchoco",
                    FactoryId = 1,
                    Quantity = 20,
                    Price = 20
                }
            };
            var requestDto = new RequestDto
            {
                ClientName = "Omar",
                WholesalerId = 1,
                ChocolateBars = chocolateBars
            };
            var chocalateBar = WholesalerTestObject.GenerateChocolateBarTest();
            var wholesalerStockDto = WholesalerTestObject.GenerateWholesalerStockDtoTest();
            var wholesaler = WholesalerTestObject.GenerateWholesalerTest();
            var stockRequestDto = WholesalerTestObject.GenerateStockRequestDtoTest();
            var wholesalerStock = WholesalerTestObject.GenerateWholesalerStockTest();

            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var chocolateBarRepositoryMock = new Mock<IChocolateBarRepository>();

            wholesalerRepositoryMock.Setup(x => x.GetWholesalerById(wholesalerStockDto.WholesalerId)).ReturnsAsync(wholesaler);
            wholesalerRepositoryMock.Setup(x => x.GetWholesalerStock(wholesalerStockDto.WholesalerId, chocalateBar.Id)).ReturnsAsync(wholesalerStock);
            chocolateBarRepositoryMock.Setup(x => x.GetChocolateBarById(chocalateBar.Id)).ReturnsAsync(chocalateBar);


            var wholesalerService = new WholesalerService(wholesalerRepositoryMock.Object, chocolateBarRepositoryMock.Object, _mapper);

            // Act
            var result = await wholesalerService.GenerateQuote(requestDto);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Discount == "10%");
        }
    }
    public class WholesalerTestObject
    {
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

        public static Wholesaler GenerateWholesalerTest()
        {
            return new Wholesaler()
            {
                Id = 1,
                Name = "ChocoLand"
            };
        }

        public static WholesalerStockDto GenerateWholesalerStockDtoTest()
        {
            return new WholesalerStockDto()
            {
                ChocolateBarId = 1,
                WholesalerId = 1,
                Quantity = 20
            };
        }

        public static WholesalerStock GenerateWholesalerStockTest()
        {
            return new WholesalerStock()
            {
                ChocolateBarId = 1,
                WholesalerId = 1,
                Quantity = 20
            };
        }

        public static StockRequestDto GenerateStockRequestDtoTest()
        {
            return new StockRequestDto()
            {
                ChocolateBarId = 1,
                Quantity = 20
            };
        }
    }
}
