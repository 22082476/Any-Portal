using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

public class TestCompanyController_Delete : IClassFixture<CompanyFixture>
{
    private readonly UserContextFixture _fixture;

    public TestCompanyController_Delete (CompanyFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_Delete_NoContent()
    {
        //Arrange
        var controller = new CompanyController (_fixture.Context);
        var dataObject =  new Company { UserId = "userId", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};
        
        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NoContentResult>(actionResult);
    }

    [Fact]
    public void Test_Delete_NotFound()
    {
        //Arrange
        var controller = new CompanyController (_fixture.Context);
        var dataObject = new Company { UserId = "userId123", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true};

        //Act
        var actionResult = controller.Delete(dataObject.UserId).GetAwaiter().GetResult();

        //Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }
}