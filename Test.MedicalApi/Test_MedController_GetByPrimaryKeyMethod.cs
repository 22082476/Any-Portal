using MedicalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.MedicalApi;

public class Test_MedController_GetByPrimaryKeyMethod
{
    [Fact]
    public async Task GetByDcode_ReturnsDisabilityForValidDcode()
    {
        // Arrange
        
        // Create options for an in-memory database.
        var options = new DbContextOptionsBuilder<DisabilityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_GetByDcode")
            .Options;

        // Using statement ensures proper disposal of the context after the block.
        using (var context = new DisabilityDbContext(options))
        {
            // Add a sample disability to the in-memory database.
            var sampleDisability = new Disability { Dcode = 1, UserId = "user1", Type = "Fysiek", Name = "Amputatie", Tool = "Arm extensie" };
            context.Disabilities.Add(sampleDisability);
            context.SaveChanges(); // Save changes to the in-memory database.
        }

        // Create a new context for querying the in-memory database.
        using (var context = new DisabilityDbContext(options))
        {
            var controller = new MedicalController(context);

            // Act
            var result = await controller.GetByDcode(1); // Call the GetByDcode method in the controller.

            // Assert
            Assert.IsType<OkObjectResult>(result); // Assert that the result is an OkObjectResult.

            var okResult = result as OkObjectResult;
            var returnedDisability = okResult.Value as Disability;

            Assert.NotNull(returnedDisability); // Assert that the returned disability is not null.
            Assert.Equal(1, returnedDisability.Dcode); // Assert that the Dcode matches the expected value.
            Assert.Equal("user1", returnedDisability.UserId); // Assert that the UserId matches the expected value.
        }
    }

   [Fact]
    public async Task GetByDcode_ReturnsNotFoundForInvalidDcode()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DisabilityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_GetByDcode_NotFound")
            .Options;

        using (var context = new DisabilityDbContext(options))
        {
            // No disabilities added to the in-memory database.
        }

        using (var context = new DisabilityDbContext(options))
        {
            var controller = new MedicalController(context);

            // Act
            var result = await controller.GetByDcode(1);

            // Assert
            Assert.IsType<NotFoundResult>(result); // Assert that the result is a NotFoundResult.
        }
    }
}