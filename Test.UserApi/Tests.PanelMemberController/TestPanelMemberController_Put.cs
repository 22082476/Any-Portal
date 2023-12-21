using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestPanelMember_Put : IClassFixture<PanelMemberFixture>
{
    private readonly UserContextFixture _fixture;

    public TestPanelMember_Put (PanelMemberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Put_Ok()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, AgeId = 1, Preferred_contact = "not"};
        // dataObject.Age = _fixture.Context.PanelMembers.Single((p) => p.UserId.Equals(dataObject.UserId)).Age;

        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_Put_NotFound_InvalidMember()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var dataObject = new PanelMember { UserId = "userId123123123123", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"}; 
        
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var objectResult = actionResult as NotFoundObjectResult;

        //Assert
        Assert.IsType<NotFoundObjectResult>(actionResult);
        Assert.Equal("PanelMemeber niet gevonden", objectResult.Value);
    }

    [Fact]
    public void Test_Put_NotFound_InvalidAge()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var dataObject = new PanelMember { UserId = "userId1", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = -1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"}; 
        
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var objectResult = actionResult as NotFoundObjectResult;


        //Assert
        Assert.IsType<NotFoundObjectResult>(actionResult);
        Assert.Equal("AgeRange niet gevonden", objectResult.Value);
    }
}