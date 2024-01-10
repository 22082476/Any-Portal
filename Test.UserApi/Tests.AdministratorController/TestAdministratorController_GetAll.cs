using Microsoft.AspNetCore.Mvc;
using Moq;
using UserApi.Controllers;

namespace Test.UserApi;

public class TestAdministratorController_GetAll : IClassFixture<AdminFixture>
{
    private readonly UserContextFixture _fixture;

        public TestAdministratorController_GetAll(AdminFixture fixture)
        {
            _fixture = fixture;
        }
    
    [Fact]
    public void Test_GetAll_Ok()
    {
        //Arrange
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.Context, mock.Object);
        
        //Act
        var actionResult = controller.GetAll().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }

    [Fact]
    public void Test_GetAll_Ok_Empty()
    {
        //Arrange
        var mock = new Mock<ILog>();
        var controller = new AdministratorController (_fixture.ContextWithout, mock.Object);
        
        //Act
        var actionResult = controller.GetAll().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }
}