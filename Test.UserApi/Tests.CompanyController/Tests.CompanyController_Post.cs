using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestCompanyController_Post : IClassFixture<CompanyFixture>
{
    private readonly UserContextFixture _fixture;

    public TestCompanyController_Post (CompanyFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Post_Ok()
    {
        //Arrange
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId3", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        
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
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        //Act
        var actionResult = controller.Post(dataObject).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<BadRequestObjectResult>(actionResult);
    }
}