using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestAdministratorController_Put : IClassFixture<AdminFixture>
{
    private readonly AdminFixture _fixture;

    public TestAdministratorController_Put (AdminFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Put_Ok()
    {
        //Arrange
        var controller = new AdministratorController (_fixture.Context);
        var dataObject = new Administrator { UserId = "userId", Email = "test213@mail.nl", FirstName = "naampje", LastName = "achternaampje", IsAdmin = false };
        
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_Put_BadRequest()
    {
        //Arrange
        var controller = new AdministratorController (_fixture.Context);
        var dataObject = new Administrator { UserId = "userIdtje", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", IsAdmin = false };
        
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}