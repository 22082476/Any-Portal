
using Xunit;
using ChatApi.Controllers;
using Moq;
using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Test.ChatApi;
public class TestUpdateChat : IClassFixture<ChatFixture>
{
    private readonly ChatContextFixture _fixture;
    public TestUpdateChat(ChatFixture fixture){
        _fixture = fixture;
    }
    [Fact]
    public void UpdateChat()
    {
        //arrange
        var controller = new ChatController(_fixture.Context);
        var chat = new Chat{ChatId = 1, UserOne = "ABCD", UserTwo = "EGH"};

        //act
        OkObjectResult result = controller.Update(chat) as OkObjectResult; 
        Console.WriteLine(result.Value);

        //assert
        Assert.IsType<OkObjectResult>(result); 
        Assert.Equal(200,result.StatusCode);
    }

    [Fact]
    public void UpdateChatFaulty()
    {
        //arrange
        var controller = new ChatController(_fixture.ContextWithout);
        var chatfaulty = new Chat{ChatId = 1, UserTwo = "EFGH"};

        //act
        BadRequestObjectResult result = controller.Update(chatfaulty) as BadRequestObjectResult; 

        //assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}