using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestAdministratorController_Post : IClassFixture<AdminFixture>
{
    private readonly UserContextFixture _fixture;

    public TestAdministratorController_Post (AdminFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Post_Ok()
    {
        //Arrange
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        var dataObject = new Administrator { UserId = "userId3", Email = "test@mail.nl3", FirstName = "Firstname3", LastName = "Lastname3", IsAdmin = false };
        
        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_Post_BadRequest()
    {
        //Arrange
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        var dataObject = new Administrator { UserId = "userId", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", IsAdmin = false };
        
        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<BadRequestObjectResult>(actionResult);
    }
}