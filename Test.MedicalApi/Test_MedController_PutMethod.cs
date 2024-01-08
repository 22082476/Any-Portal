using MedicalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.MedicalApi;

    public class Test_MedController_PutMethod
    {
        [Fact]
        public async Task Update_ReturnsNoContentForSuccessfulUpdate()
        {
            // Arrange
            
            // Create options for an in-memory database.
            var options = new DbContextOptionsBuilder<DisabilityDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Update")
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
                // Create an updated Disability with the same Dcode.
                var updatedDisability = new Disability
                {
                    Dcode = 1,
                    UserId = "user1",
                    Type = "Fysiek",
                    Name = "Updated Amputatie",
                    Tool = "Updated Arm extensie"
                };

                // Detach the existing entity from the context to avoid conflicts.
                context.Entry(sampleDisability).State = EntityState.Detached;

                // Call the Update method in the controller.
                var result = await controller.Update(1, updatedDisability);

                // Assert
                Assert.IsType<NoContentResult>(result); // Assert that the result is a NoContentResult.
            }
        }

        [Fact]
        public async Task Update_ReturnsBadRequestForMismatchedDcode()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DisabilityDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Update_BadRequest")
                .Options;

            using (var context = new DisabilityDbContext(options))
            {
                var controller = new MedicalController(context);

                // Act
                // Create an updated Disability with a mismatched Dcode.
                var updatedDisability = new Disability
                {
                    Dcode = 2, // Mismatched Dcode
                    UserId = "user1",
                    Type = "Fysiek",
                    Name = "Updated Amputatie",
                    Tool = "Updated Arm extensie"
                };

                var result = await controller.Update(1, updatedDisability);

                // Assert
                Assert.IsType<BadRequestResult>(result); // Assert that the result is a BadRequestResult.
            }
        }
    }