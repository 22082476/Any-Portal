using MedicalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.MedicalApi;

// This class serves as a test fixture. It implements IDisposable to handle resource cleanup.
public class MedicalControllerFixture : IDisposable
{
    // This property holds an instance of the DisabilityDbContext used for testing.
    public DisabilityDbContext Context { get; }

    // Constructor for the test fixture. It sets up an in-memory database for testing purposes.
    public MedicalControllerFixture()
    {
        var options = new DbContextOptionsBuilder<DisabilityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_Delete")
            .Options;

        Context = new DisabilityDbContext(options);
    }

    // Dispose method to clean up resources when the test fixture is no longer needed.
    public void Dispose()
    {
        // Clean up resources, specifically, dispose of the in-memory database context.
        Context.Dispose();
    }
}

    public class Test_MedController_DeleteMethod : IClassFixture<MedicalControllerFixture>
{
    // These private fields store instances of the MedicalController and DisabilityDbContext for testing.
    private readonly MedicalController _controller;
    private readonly DisabilityDbContext _context;

    // Constructor for the test class. It takes a test fixture as a parameter to get the shared context.
    public Test_MedController_DeleteMethod(MedicalControllerFixture fixture)
    {
        _context = fixture.Context;
        _controller = new MedicalController(_context);
    }

    [Fact]
    public async Task Delete_ReturnsNoContentForSuccessfulDeletion()
    {
        // Arrange
        
        // Create a sample disability and add it to the shared in-memory database.
        var sampleDisability = new Disability { Dcode = 1, UserId = "user1", Type = "Fysiek", Name = "Amputatie", Tool = "Arm extensie" };
        _context.Disabilities.Add(sampleDisability);
        _context.SaveChanges(); // Save changes to the shared in-memory database.

        // Act
        // Call the Delete method in the controller.
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result); // Assert that the result is a NoContentResult, indicating a successful deletion.

        // Verify that the disability has been removed from the database.
        var deletedDisability = await _context.Disabilities.FindAsync(1);
        Assert.Null(deletedDisability); // Assert that the deleted disability is null (not found in the database).
    }

    [Fact]
    public async Task Delete_ReturnsNotFoundForNonExistingDisability()
    {
        // Act
        // Call the Delete method in the controller for a non-existing disability.
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NotFoundResult>(result); // Assert that the result is a NotFoundResult.
    }
}