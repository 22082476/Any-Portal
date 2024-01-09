using Microsoft.AspNetCore.Mvc;
using ResearchApi;
public class TestGetFunction : IClassFixture<ResearchFixture>{
    private readonly ResearchContextFixture _fixture;
    public TestGetFunction(ResearchFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void Get_One_Research(){
    var controller = new ResearchController(_fixture.Context);
    var result = controller.GetResearch(1);
    Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public void Get_All_Research(){
    var controller = new ResearchController(_fixture.Context);
    var result = controller.GetAllResearch();
    Assert.IsType<OkObjectResult>(result);
    
    }
}