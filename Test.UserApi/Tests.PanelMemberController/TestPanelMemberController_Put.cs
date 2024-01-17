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
        var panelMember =  new PanelMember { UserId = "userId", Email = "tessadt@mail.nl", PhoneNumber = 061111, FirstName = "Firstnaame", LastName = "Lastaname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "yes", CaretakerId = "1"}; 
        var panelMemberNew = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "not", CaretakerId = "1"}; 
        var caretaker = new Caretaker {CaretakerId = "1", Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = 0};
        var dataObject = new RequestModelPut {PanelMemberCurrent = panelMember, PanelMemberNew = panelMemberNew, Caretaker = caretaker};
        
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
    }

    [Fact]
    public void Test_Put_NotFound_InvalidMember()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var panelMember =  new PanelMember { UserId = "userId12312132312", Email = "tessadt@mail.nl", PhoneNumber = 061111, FirstName = "Firstnaame", LastName = "Lastaname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "yes", CaretakerId = "1"}; 
        var panelMemberNew = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "not", CaretakerId = "1"}; 
        var caretaker = new Caretaker {CaretakerId = "1", Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = 0};
        var dataObject = new RequestModelPut {PanelMemberCurrent = panelMember, PanelMemberNew = panelMemberNew, Caretaker = caretaker};
       
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var objectResult = actionResult as NotFoundObjectResult;

        //Assert
        Assert.IsType<NotFoundObjectResult>(actionResult);
        Assert.Equal("PanelMember niet gevonden", objectResult.Value);
    }

    [Fact]
    public void Test_Put_NotFound_InvalidAge()
    {
        //Arrange
        var mockService = new Mock<IResearchApiService>();
        var controller = new PanelMemberController (_fixture.Context, mockService.Object); 
        var panelMember =  new PanelMember { UserId = "userId", Email = "tessadt@mail.nl", PhoneNumber = 061111, FirstName = "Firstnaame", LastName = "Lastaname", AgeId = 0, PostalCode = "2002 ET", Availability = "", Preferred_contact = "yes", CaretakerId = "1"}; 
        var panelMemberNew = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 0, PostalCode = "2002 ET", Availability = "", Preferred_contact = "not", CaretakerId = "1"}; 
        var caretaker = new Caretaker {CaretakerId = "1", Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = 0};
        var dataObject = new RequestModelPut {PanelMemberCurrent = panelMember, PanelMemberNew = panelMemberNew, Caretaker = caretaker};
       
        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();
        var objectResult = actionResult as NotFoundObjectResult;


        //Assert
        Assert.IsType<NotFoundObjectResult>(actionResult);
        Assert.Equal("AgeRange niet gevonden", objectResult.Value);
    }
}