using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestAdministratorController_Delete : IClassFixture<AdminFixture>
{
    private readonly UserContextFixture _fixture;

    public TestAdministratorController_Delete (AdminFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Delete_NoContent()
    {
        //Arrange
        var controller = new AdministratorController (_fixture.Context);
        var dataObject = new Administrator { UserId = "userId", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", IsAdmin = false };
        
        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();
        var resultObject = actionResult as NoContentResult;

        //Assert
        Assert.IsType<NoContentResult>(actionResult);
        Assert.Equal(204, resultObject.StatusCode);
    }

    [Fact]
    public void Test_Delete_NotFound()
    {
        //Arrange
        var controller = new AdministratorController (_fixture.Context);
        var dataObject = new Administrator { UserId = "userId12", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", IsAdmin = false };
        
        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}