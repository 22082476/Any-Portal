using Microsoft.AspNetCore.Mvc;

using UserApi.Controllers;

namespace Test.UserApi;

public class TestCompanyController_GetAll : IClassFixture<CompanyFixture>
{
    private readonly UserContextFixture _fixture;

        public TestCompanyController_GetAll(CompanyFixture fixture)
        {
            _fixture = fixture;
        }
    
    [Fact]
    public void Test_GetAll_Ok()
    {
        //Arrange
        
        var controller = new CompanyController (_fixture.Context);
        
        //Act
        var actionResult = controller.GetAll(false).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }

    [Fact]
    public void Test_GetAll_Ok_Empty()
    {
        //Arrange
        
        var controller = new CompanyController (_fixture.ContextWithout);
        
        //Act
        var actionResult = controller.GetAll(false).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }
}