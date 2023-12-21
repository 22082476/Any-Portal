
using Xunit;
using ChatApi.Controllers;
using Moq;
using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Test.ChatApi;
public class TestDeleteChat : IClassFixture<ChatFixture>
{
    private readonly ChatContextFixture _fixture;
    public TestDeleteChat(ChatFixture fixture){
        _fixture = fixture;
    }
    [Fact]
    public void DeleteChat()
    {
        //arrange
        var controller = new ChatController(_fixture.Context);
        var chat = new Chat{ChatId = 1, UserOne = "ABCD", UserTwo = "EFGH"};

        //act
        OkObjectResult result = controller.Delete(chat) as OkObjectResult; 

        //assert
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200,result.StatusCode);
    }

    [Fact]
    public void DeleteChatFaulty()
    {
        //arrange
        var controller = new ChatController(_fixture.Context);
        var chatfaulty = new Chat{UserTwo = "EFGH", UserOne = "ABCD"};

        //act
        BadRequestObjectResult result = controller.Delete(chatfaulty) as BadRequestObjectResult; 

        //assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}