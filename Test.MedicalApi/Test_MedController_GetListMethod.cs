using MedicalApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.MedicalApi;

 public class Test_MedController_GetListMethod
{
    [Fact]
    public async Task Get_ReturnsListOfDisabilities()
    {
        // Arrange
        
        // Create options for an in-memory database.
        var options = new DbContextOptionsBuilder<DisabilityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Using statement ensures proper disposal of the context after the block.
        using (var context = new DisabilityDbContext(options))
        {
            // Add sample disabilities to the in-memory database.
            context.Disabilities.AddRange(new List<Disability>
            {
                new Disability { UserId = "user1", Type = "Fysiek", Name = "Amputatie", Tool = "Arm extensie" },
                new Disability { UserId = "user2", Type = "Visueel", Name = "Blind", Tool = "Voorlees app" },
            });

            context.SaveChanges(); // Save changes to the in-memory database.
        }

        // Create a new context for querying the in-memory database.
        using (var context = new DisabilityDbContext(options))
        {
            var controller = new MedicalController(context);

            // Act
            var result = await controller.GetOwn(""); // Call the Get method in the controller.

            // Assert
            Assert.IsType<OkObjectResult>(result); // Assert that the result is an OkObjectResult.

            var okResult = result as OkObjectResult;
            var returnedDisabilities = okResult.Value as List<Disability>;

            Assert.NotNull(returnedDisabilities); // Assert that the returned list is not null.
            Assert.Equal(2, returnedDisabilities.Count); // Assuming two disabilities in Arrange.
        }
    }
}