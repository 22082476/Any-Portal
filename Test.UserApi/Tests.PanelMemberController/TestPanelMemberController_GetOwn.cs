using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace Test.UserApi;

public class TestPanelMemberController_GetOwn : IClassFixture<PanelMemberFixture>
{
    private readonly UserContextFixture _fixture;

    public TestPanelMemberController_GetOwn(PanelMemberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Test_GetOwn_Ok()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"};
        
        //Act
        var actionResult = controller.GetOwn(dataObject.UserId).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_GetOwn_NotFound()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        
        //Act
        var actionResult = controller.GetOwn("user").GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}