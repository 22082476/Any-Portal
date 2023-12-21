using Microsoft.AspNetCore.Mvc;
using Moq;
using UserApi.Controllers;

namespace Test.UserApi;

public class TestPanelMemberController_GetAll : IClassFixture<PanelMemberFixture>
{
    private readonly UserContextFixture _fixture;

        public TestPanelMemberController_GetAll(PanelMemberFixture fixture)
        {
            _fixture = fixture;
        }
    
    [Fact]
    public void Test_GetAll_Ok()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        
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
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
       
        //Act
        var actionResult = controller.GetAll().GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(resultObject.Value);
    }
}