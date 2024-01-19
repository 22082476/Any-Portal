using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestAdministratorController_Put : IClassFixture<AdminFixture>
{
    private readonly UserContextFixture _fixture;

    public TestAdministratorController_Put (AdminFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Put_Ok()
    {
        //Arrange
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        var dataObject = new Administrator { UserId = "userId", Email = "test213@mail.nl", FirstName = "naampje", LastName = "achternaampje", PhoneNumber = "+31 606060", IsAdmin = false };
        
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
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        var dataObject = new Administrator { UserId = "userIdtje", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", PhoneNumber = "+31 606060", IsAdmin = false };
        
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<BadRequestResult>(actionResult);
    }
}