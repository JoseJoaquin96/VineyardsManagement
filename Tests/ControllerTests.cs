using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using VineyardsManagement.Controllers;
using VineyardsManagement.DB;
using VineyardsManagement.Models;

namespace VineyardsManagement.Tests.Controllers
{
    public class ManagersControllerTests
    {
        private VineyardDBContext CreateContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<VineyardDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new VineyardDBContext(options);
        }

        private void SeedTestData(VineyardDBContext context)
        {
            // Creo parcelas de prueba
            var parcel1 = new Parcels { Id = 1, Area = 1500 };
            var parcel2 = new Parcels { Id = 2, Area = 9000 };
            var parcel3 = new Parcels { Id = 3, Area = 3000 };
            var parcel4 = new Parcels { Id = 4, Area = 2000 };
            var parcel5 = new Parcels { Id = 5, Area = 1000 };

            // Crear managers de prueba
            var manager1 = new Managers
            {
                Id = 1,
                Name = "Miguel Torres",
                TaxNumber = "132254524"
            };

            var manager2 = new Managers
            {
                Id = 2,
                Name = "Ana Martin",
                TaxNumber = "143618668"
            };

            var manager3 = new Managers
            {
                Id = 3,
                Name = "Carlos Ruiz",
                TaxNumber = "78903228"
            };

            // Agregar managers y parcelas a la base de datos
            context.Managers.AddRange(manager1, manager2, manager3);
            context.SaveChanges();

            // Agregar parcelas y establecer la relación con los managers
            parcel1.ManagerId = manager1.Id;
            parcel2.ManagerId = manager2.Id;
            parcel3.ManagerId = manager3.Id;
            parcel4.ManagerId = manager1.Id;
            parcel5.ManagerId = manager3.Id;

            context.Parcels.AddRange(parcel1, parcel2, parcel3, parcel4, parcel5);
            context.SaveChanges();
        }

        [Fact]
        public async Task GetManagersTaxNumbers_WithSortedTrue_ReturnsTaxNumbersOrderedByName()
        {
            var dbName = $"ManagersDb_{Guid.NewGuid()}";
            var context = CreateContext(dbName);
            SeedTestData(context);

            var controller = new ManagersController(context);

            var result = await controller.GetManagersTaxNumbers(sorted: true);

            var actionResult = Assert.IsType<ActionResult<List<Managers>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var taxNumbers = Assert.IsType<List<string>>(okResult.Value);

            Assert.Equal(3, taxNumbers.Count);

            // Verificamos que estén ordenados por nombre de manager (Ana, Carlos, Miguel)
            Assert.Equal("143618668", taxNumbers[0]); // Ana
            Assert.Equal("78903228", taxNumbers[1]); // Carlos
            Assert.Equal("132254524", taxNumbers[2]); // Miguel

            // Liberamos espacio y recursos
            await context.DisposeAsync();
        }

        [Fact]
        public async Task GetTotalAreaByManager_ReturnsDictionaryWithTotalAreas()
        {
            var dbName = $"ManagersDb_{Guid.NewGuid()}";
            var context = CreateContext(dbName);
            SeedTestData(context);

            var controller = new ManagersController(context);

            var result = await controller.GetTotalAreaByManager();

            var actionResult = Assert.IsType<ActionResult<Dictionary<string, int>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var totalAreaByManager = Assert.IsType<Dictionary<string, int>>(okResult.Value);

            Assert.Equal(3, totalAreaByManager.Count);
            Assert.Equal(3500, totalAreaByManager["Miguel Torres"]); // 1500 + 2000
            Assert.Equal(9000, totalAreaByManager["Ana Martin"]); // 9000
            Assert.Equal(4000, totalAreaByManager["Carlos Ruiz"]); // 3000 + 1000

            // Liberamos espacio y recursos
            await context.DisposeAsync();
        }
    }
}