using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestPanelMemberController_Post : IClassFixture<PanelMemberFixture>
{
    private readonly UserContextFixture _fixture;

    public TestPanelMemberController_Post (PanelMemberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Post_Ok()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var panelMember = new PanelMember { UserId = "userId4", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not", CaretakerId = 1}; 
        var caretaker = new Caretaker {CaretakerId = 1, Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = 0};
        var dataObject = new RequestModel {PanelMemberNew = panelMember, Caretaker = caretaker};
        
        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
    }

    [Fact]
    public void Test_Post_BadRequest()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var panelMember = new PanelMember { UserId = "userId4", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not", CaretakerId = 1}; 
        var caretaker = new Caretaker {CaretakerId = 1, Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = 0};
        var dataObject = new RequestModel {PanelMemberNew = panelMember, Caretaker = caretaker};
       
        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();
        var objectResult = actionResult as BadRequestObjectResult;

        //Assert
        Assert.IsType<BadRequestObjectResult>(actionResult);
        Assert.Equal("Account bestaat al", objectResult.Value);
    }
}