using Xunit;
using ChatApi.Controllers;
using Moq;
using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;

namespace Test.ChatApi;
public class TestDeleteChatMessage : IClassFixture<ChatWithMessageFixture>
{
    private readonly ChatContextFixture _fixture;
    public TestDeleteChatMessage(ChatWithMessageFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void TestDeleteChatMessages()
    {
        //arrange
       var controller = new ChatController(_fixture.MessageContext);
        ChatMessage message = new ChatMessage{
                        MessageId = 1, ChatId = 1, Message = "hey geert", SentFrom = "ABCD", DateTime = new DateTime(2023, 4, 15, 13, 30, 0)
                    };

        //act
        var result = controller.DeleteMessage(message).GetAwaiter().GetResult()  as NoContentResult;

        //assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void TestGetDeleteMessagesFaulty()
    {
        //arrange
       var controller = new ChatController(_fixture.MessageContext);
       ChatMessage message = new ChatMessage{
                        Message = "hey geert", SentFrom = "ABCD", DateTime = new DateTime(2023, 4, 15, 13, 30, 0)
                    };

        //act
        var result = controller.DeleteMessage(message).GetAwaiter().GetResult() as BadRequestObjectResult;

        //assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

}