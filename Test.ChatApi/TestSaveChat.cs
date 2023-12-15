
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
        var chat = new Chat{ChatId = 1, UserOne = "ABCD", UserTwo = "EFGH", Messages = {new ChatMessage{ChatId = 1 ,MessageId = 1 ,DateTime = DateTime.Now ,SentFrom = "ABCD" , Message = "Hallo geert"}}};

        //act
        OkObjectResult result = controller.Save(chat) as OkObjectResult; 

        //assert
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200,result.StatusCode);
    }

    public void SaveChatFaulty()
    {
        //arrange
        var controller = new ChatController(_fixture.ContextWithout);
        var chatfaulty = new Chat{ChatId = 1, UserTwo = "EFGH", Messages = {new ChatMessage{ChatId = 1 ,MessageId = 1 ,DateTime = DateTime.Now ,SentFrom = "ABCD" , Message = "Hallo geert"}}};

        //act
        BadRequestObjectResult result = controller.Save(chatfaulty) as BadRequestObjectResult; 

        //assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}