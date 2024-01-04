
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ResearchApi;

public class TestDeletefunction : IClassFixture<ResearchFixture>{
    private readonly ResearchContextFixture _fixture;
    public TestDeletefunction(ResearchFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void TestDeleteResearch_WithExistingTest(){
        var controller = new ResearchController(_fixture.Context);

        var result = controller.DeleteResearch(1);

        Assert.IsType<NoContentResult>(result);
    }

     [Fact]
    public void TestDeleteResearch_NotExisting(){
        var controller = new ResearchController(_fixture.Context);

        var result = controller.DeleteResearch(3);

          Assert.IsType<NotFoundResult>(result);
    }
}
