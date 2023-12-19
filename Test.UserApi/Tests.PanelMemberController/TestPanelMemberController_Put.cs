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
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Age = new AgeRange { RangeName = "rang1", AgeStart = 1, AgeEnd = 18}, Preferred_contact = "not"};
        // dataObject.Age = _fixture.Context.PanelMembers.Single((p) => p.UserId.Equals(dataObject.UserId)).Age;

        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(dataObject.ToString(), resultObject.Value.ToString());
    }

    [Fact]
    public void Test_Put_BadRequest()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var dataObject = new PanelMember { UserId = "userId123123123123", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", Age = new AgeRange {RangeName = "range1", AgeStart = 1, AgeEnd = 18}, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"}; 
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<BadRequestResult>(actionResult);
    }
}