using Microsoft.AspNetCore.Mvc;

using UserApi.Controllers;

namespace Test.UserApi;

public class TestUserDataController_GetAges : IClassFixture<UserDataFixture>
{
    private readonly UserContextFixture _fixture;
        public TestUserDataController_GetAges (UserDataFixture fixture)
        {
            _fixture = fixture;
        }
    
    [Fact]
    public void Test_GetAge_Ok()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new AgeRange{ AgeId = 1, AgeStart = 1, AgeEnd = 18};

        
        //Act
        var actionResult = controller.GetAge(dataObject.AgeId).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_GetAge_NotFound()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new AgeRange{ AgeId = 1123, AgeStart = 1, AgeEnd = 18};
        
        //Act
        var actionResult = controller.GetAge(dataObject.AgeId).GetAwaiter().GetResult();
        
        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }

    [Fact]
    public void Test_GetAges_Ok()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        
        //Act
        var actionResult = controller.GetAges().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }

    [Fact]
    public void Test_GetAges_Ok_Empty()
    {
        //Arrange
        var controller = new UserDataController (_fixture.ContextWithout);
        
        //Act
        var actionResult = controller.GetAges().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }
}