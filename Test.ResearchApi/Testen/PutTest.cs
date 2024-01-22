
using Microsoft.AspNetCore.Mvc;
using ResearchApi;
public class TestPutfunction : IClassFixture<ResearchFixture>{
    private readonly ResearchContextFixture _fixture;
    public TestPutfunction(ResearchFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void Put_Research_SetActive_False(){
    var controller = new ResearchController(_fixture.Context);
    Research research = new Research(){Title = "Titel", Compensation = 100.0m, Type_Research = "Type", Link_Research = "Link", Disability_Type =[""], Description = ""};
    var result = controller.UpdateResearch(2, research);
     Assert.IsType<BadRequestResult>(result);
    }

   
  
}