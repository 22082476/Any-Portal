using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestCompanyController_Put : IClassFixture<CompanyFixture>
{
    private readonly UserContextFixture _fixture;

    public TestCompanyController_Put (CompanyFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Put_Ok()
    {
        //Arrange
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        
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
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId1213", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        //Act
        var actionResult = controller.Put(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}