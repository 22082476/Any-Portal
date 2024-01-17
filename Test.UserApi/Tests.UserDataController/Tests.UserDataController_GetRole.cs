using Microsoft.AspNetCore.Mvc;

using UserApi.Controllers;

namespace Test.UserApi;

public class TestUserDataController_GetRole : IClassFixture<UserDataFixture>
{
    private readonly UserContextFixture _fixture;
        public TestUserDataController_GetRole (UserDataFixture fixture)
        {
            _fixture = fixture;
        }
    
    [Fact]
    public void Test_GetRole_Ok_PanelMember()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "not"};
;

        
        //Act
        var actionResult = controller.GetRole(dataObject.UserId).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal("PanelMember", resultObject.Value.ToString());
    }

    [Fact]
    public void Test_GetRole_Ok_Company()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new Company { UserId = "userId5", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};
;

        
        //Act
        var actionResult = controller.GetRole(dataObject.UserId).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal("Company", resultObject.Value.ToString());
    }

    [Fact]
    public void Test_GetRole_Ok_Administrator()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new Administrator { UserId = "userId6", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", IsAdmin = false };
;

        
        //Act
        var actionResult = controller.GetRole(dataObject.UserId).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal("Administrator", resultObject.Value.ToString());
    }

    [Fact]
    public void Test_GetRole_Ok_Admin()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new Administrator { UserId = "userId7", Email = "test2@mail.nl", FirstName = "Firstname2", LastName = "Lastname2", IsAdmin = true }
;

        
        //Act
        var actionResult = controller.GetRole(dataObject.UserId).GetAwaiter().GetResult();
        var resultObject = actionResult as OkObjectResult;
        
        //Assert
        Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal("Admin", resultObject.Value.ToString());
    }

    [Fact]
    public void Test_GetRole_NotFound()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        var dataObject = new { UserId = "onzin"};
        
        //Act
        var actionResult = controller.GetRole(dataObject.UserId).GetAwaiter().GetResult();
        
        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }


    [Fact]
    public void Test_GetRole_BadRequest()
    {
        //Arrange
        var controller = new UserDataController (_fixture.Context);
        
        //Act
        var actionResult = controller.GetRole(null!).GetAwaiter().GetResult();
        
        //Assert
        Assert.IsType<BadRequestResult>(actionResult);
    }
    
}