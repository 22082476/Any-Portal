using Microsoft.AspNetCore.Mvc;

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
        
        var controller = new AdministratorController (_fixture.Context);
        
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
        
        var controller = new AdministratorController (_fixture.ContextWithout);
        
        //Act
        var actionResult = controller.GetAll().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }
}