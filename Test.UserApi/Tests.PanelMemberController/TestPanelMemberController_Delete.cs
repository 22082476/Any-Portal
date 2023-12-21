using Microsoft.AspNetCore.Mvc;
using Moq;
using UserApi.Controllers;

public class TestPanelMemberController_Delete : IClassFixture<PanelMemberFixture>
{
    private readonly UserContextFixture _fixture;

    public TestPanelMemberController_Delete (PanelMemberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Delete_Ok()
    {
        //Arrange
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"};    
        var mockService = new Mock<IResearchApiService>();
        mockService.Setup((m) => m.GetFromResearchApi(It.IsAny<string>())).ReturnsAsync(() => (bool?)true);

        var controller = new PanelMemberController (_fixture.Context, mockService.Object);    

        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();
        var objectResult = actionResult as OkObjectResult;
        dataObject.UpdateToNull();

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), objectResult.Value.ToString());
    }

    [Fact]
    public void Test_Delete_NoContent()
    {
        //Arrange
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"};    
        var mockService = new Mock<IResearchApiService>();
        mockService.Setup((m) => m.GetFromResearchApi(It.IsAny<string>())).ReturnsAsync(() => (bool?)false);

        var controller = new PanelMemberController (_fixture.Context, mockService.Object);    

        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NoContentResult>(actionResult);
    }

    [Fact]
    public void Test_Delete_NotFound()
    {
        //Arrange
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"};    
        var mockService = new Mock<IResearchApiService>();

        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        
        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}