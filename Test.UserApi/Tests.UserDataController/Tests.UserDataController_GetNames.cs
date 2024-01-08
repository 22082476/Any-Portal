using Microsoft.AspNetCore.Mvc;

using UserApi.Controllers;

namespace Test.UserApi;

public class TestUserDataController_GetNames : IClassFixture<UserDataFixture>
{
    private readonly UserContextFixture _fixture;

        public TestUserDataController_GetNames(UserDataFixture fixture)
        {
            _fixture = fixture;
        }
    
    [Fact]
    public void Test_GetAll_Ok()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
                
        //Act
        var actionResult = controller.GetNames().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }

    [Fact]
    public void Test_GetAll_Ok_Empty()
    {
        //Arrange
        
        var controller = new UserDataController (_fixture.ContextWithout);
        
        //Act
        var actionResult = controller.GetNames().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }
}