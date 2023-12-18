using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using UserApi.Controllers;

namespace Test.UserApi;

public class TestCompanyController_GetOwn : IClassFixture<CompanyFixture>
{
    private readonly UserContextFixture _fixture;

        public TestCompanyController_GetOwn(CompanyFixture fixture)
        {
            _fixture = fixture;
        }

    [Fact]
    public void Test_GetOwn_Ok()
    {
        //Arrange
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        
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
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId1213", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        //Act
        var actionResult = controller.GetOwn(dataObject.UserId).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}