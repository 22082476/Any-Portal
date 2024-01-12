
using Microsoft.AspNetCore.Mvc;
using ResearchApi;
public class TestPostfunction : IClassFixture<ResearchFixture>{
    private readonly ResearchContextFixture _fixture;
    public TestPostfunction(ResearchFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void Post_Research_WithAllNecessaryInformation(){
        var controller = new ResearchController(_fixture.Context);
        Research research = new Research(){Title = "Titel", Compensation = 100.0m, Type_Research = "Type", Link_Research = "Link", Company = "Company", CompanyId= "1"};
        var result = controller.CreateResearch(research);
         Assert.IsType<OkObjectResult>(result);

    }

    [Fact]
    public void Post_Research_WithAllInformation(){
        var controller = new ResearchController(_fixture.Context);
        Research research = new Research(){Active = true, Title = "Titel", Compensation = 100.0m, Type_Research = "Type", Link_Research = "Link",  Disability_Type = new List<string>(){"a", "b"}, Company = "Company", CompanyId = "2"};
        var result = controller.CreateResearch(research);
         Assert.IsType<OkObjectResult>(result);

    }

    [Fact]
    public void Post_Research_Null(){
        var controller = new ResearchController(_fixture.Context);
        var result = controller.CreateResearch(null);
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Post_Participant_WithInformation(){
        var controller = new ResearchController(_fixture.Context);
        Participant participant = new Participant(){ResearchId = 12, UserId = "ABCD"};
        var result = controller.CreateParticipant(participant);
         Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public void Post_Participant_Null(){
        var controller = new ResearchController(_fixture.Context);
        var result = controller.CreateParticipant(null);
        Assert.IsType<BadRequestResult>(result);
    }

     [Fact]
    public void Post_PostalcodeRange_WithInformation(){
        var controller = new ResearchController(_fixture.Context);
        PostalCodeRange postalCodeRange = new PostalCodeRange(){From_Postalcode = "2531RL", Till_Postalcode = "2588YZ", ResearchId = 12};
        var result = controller.CreatePostalcodeRange(postalCodeRange);
        Assert.IsType<OkObjectResult>(result);
    }

     
    [Fact]
        public void Post_PostalcodeRange_Null(){
        var controller = new ResearchController(_fixture.Context);
        var result = controller.CreatePostalcodeRange(null);
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Post_Allowed_AgeRange_WithInformation(){
        var controller = new ResearchController(_fixture.Context);
        Allowed_AgeRange allowed_AgeRange = new Allowed_AgeRange(){ResearchId = 22, Allowed_AgeRangeId = 13};
        var result = controller.CreateAllowed_AgeRange(allowed_AgeRange);
        Assert.IsType<OkObjectResult>(result);
    }
    
     [Fact]
    public void Post_Allowed_AgeRange_Null(){
        var controller = new ResearchController(_fixture.Context);
        var result = controller.CreateAllowed_AgeRange(null);
        Assert.IsType<BadRequestResult>(result);
    }
}