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
        var dataObject = new PanelMember { UserId = "userId4", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", Age = new AgeRange {RangeName = "range1", AgeStart = 1, AgeEnd = 18}, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"}; 
        
        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_Post_BadRequest()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", Age = new AgeRange {RangeName = "range1", AgeStart = 1, AgeEnd = 18}, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"};
       
        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<BadRequestObjectResult>(actionResult);
    }
}