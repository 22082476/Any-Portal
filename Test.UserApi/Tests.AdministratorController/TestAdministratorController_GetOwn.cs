using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace Test.UserApi;

public class TestAdministratorController_getOwn : IClassFixture<AdminFixture>
{

    private readonly UserContextFixture _fixture;

        public TestAdministratorController_getOwn(AdminFixture fixture)
        {
            _fixture = fixture;
        }
       
    [Fact]
    public void Test_GetOwn_Ok()
    {
        //Arrange
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        var dataObject = new Administrator { UserId = "userId", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", PhoneNumber = "+31 606060", IsAdmin = false };
        
        //Act
        var actionResult = controller.GetOwn("userId").GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());

    }

    [Fact]
    public void Test_GetOwn_NotFound ()
    {
        //Arrang
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        
        //Act
        var actionResult = controller.GetOwn("user").GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);

    }
}