
using Xunit;
using ChatApi.Controllers;
using Moq;
using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Test.ChatApi;
public class TestSaveChat : IClassFixture<ChatFixture>
{
    private readonly ChatContextFixture _fixture;
    public TestSaveChat(ChatFixture fixture){
        _fixture = fixture;
    }
    [Fact]
    public void SaveChat()
    {
        //arrange
        var controller = new ChatController(_fixture.ContextWithout);
        var chat = new Chat{ChatId = 1, UserOne = "ABCD", UserTwo = "EFGH"};

        //act
        OkObjectResult result = controller.Save(chat).Result as OkObjectResult; 

        //assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void SaveChatFaulty()
    {
        //arrange
        var controller = new ChatController(_fixture.ContextWithout);
        var chatfaulty = new Chat{ChatId = 1, UserTwo = "EFGH"};

        //act
        BadRequestObjectResult result = controller.Save(chatfaulty).Result as BadRequestObjectResult; 

        //assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}