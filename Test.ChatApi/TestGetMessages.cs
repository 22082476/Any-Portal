using Xunit;
using ChatApi.Controllers;
using Moq;
using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;

namespace Test.ChatApi;
public class TestGetChatMessage : IClassFixture<ChatWithMessageFixture>
{
    private readonly ChatContextFixture _fixture;
    public TestGetChatMessage(ChatWithMessageFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void TestGetChatMessages()
    {
        //arrange
       var controller = new ChatController(_fixture.MessageContext);
        ChatMessage message = new ChatMessage{
                        MessageId = 1, ChatId = 1, Message = "hey geert", SentFrom = "ABCD", DateTime = new DateTime(2023, 4, 15, 13, 30, 0)
                    };

        //act
        var result = controller.GetMessages(1).GetAwaiter().GetResult() as OkObjectResult;
        var SavedMessage = result.Value as IList<ChatMessage>;

        //assert
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(message.ToString(),SavedMessage.FirstOrDefault().ToString());
    }

    [Fact]
    public void TestGetChatMessagesFaulty()
    {
        //arrange
       var controller = new ChatController(_fixture.MessageContext);

        //act
        var result = controller.GetMessages(10).GetAwaiter().GetResult() as NotFoundObjectResult;
        //assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

}