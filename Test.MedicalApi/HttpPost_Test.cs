using MedicalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.MedicalApi;

    public class HttpPost_Test
    {
        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {
            // Arrange
            
            // Create options for an in-memory database.
            var options = new DbContextOptionsBuilder<DisabilityDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Create")
                .Options;

            // Using statement ensures proper disposal of the context after the block.
            using (var context = new DisabilityDbContext(options))
            {
                var controller = new MedicalController(context);

                // Act
                // Create a new Disability object to be passed to the Create method.
                var newDisability = new Disability
                {
                    UserId = "user2",
                    Type = "Visueel",
                    Name = "Blind",
                    Tool = "Voorlees app"
                };

                // Call the Create method in the controller.
                var result = await controller.Create(newDisability);

                // Assert
                Assert.IsType<CreatedAtActionResult>(result); // Assert that the result is a CreatedAtActionResult.

                var createdAtActionResult = result as CreatedAtActionResult;
                Assert.Equal(nameof(MedicalController.GetByDcode), createdAtActionResult.ActionName); // Assert the action name.
                Assert.Equal(201, createdAtActionResult.StatusCode); // Assert the status code.

                // Extract the created Disability from the response.
                var createdDisability = createdAtActionResult.Value as Disability;
                Assert.NotNull(createdDisability); // Assert that the created disability is not null.
                Assert.Equal(newDisability.UserId, createdDisability.UserId); // Assert that the UserId matches the expected value.
            }
        }
    }