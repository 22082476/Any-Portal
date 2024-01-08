using MedicalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test.MedicalApi;

    public class HttpDelete_Test
    {
        [Fact]
        public async Task Delete_ReturnsNoContentForSuccessfulDeletion()
        {
            // Arrange
            
            // Create options for an in-memory database.
            var options = new DbContextOptionsBuilder<DisabilityDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Delete")
                .Options;

            // Using statement ensures proper disposal of the context after the block.
            using (var context = new DisabilityDbContext(options))
            {
                var controller = new MedicalController(context);

                // Add a sample disability to the in-memory database.
                var sampleDisability = new Disability { Dcode = 1, UserId = "user1", Type = "Fysiek", Name = "Amputatie", Tool = "Arm extensie" };
                context.Disabilities.Add(sampleDisability);
                context.SaveChanges(); // Save changes to the in-memory database.

                // Act
                // Call the Delete method in the controller.
                var result = await controller.Delete(1);

                // Assert
                Assert.IsType<NoContentResult>(result); // Assert that the result is a NoContentResult.

                // Verify that the disability has been removed from the database.
                var deletedDisability = await context.Disabilities.FindAsync(1);
                Assert.Null(deletedDisability); // Assert that the deleted disability is null (not found in the database).
            }
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundForNonExistingDisability()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DisabilityDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Delete_NotFound")
                .Options;

            using (var context = new DisabilityDbContext(options))
            {
                var controller = new MedicalController(context);

                // Act
                // Call the Delete method in the controller for a non-existing disability.
                var result = await controller.Delete(1);

                // Assert
                Assert.IsType<NotFoundResult>(result); // Assert that the result is a NotFoundResult.
            }
        }
    }