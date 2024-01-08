
using Xunit;
using ChatApi.Controllers;
using Moq;
using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;

namespace Test.ChatApi;
public class TestGetChats : IClassFixture<ChatFixture>
{
    private readonly ChatContextFixture _fixture;
    public TestGetChats(ChatFixture fixture){
        _fixture = fixture;
    }

    [Fact]
    public void TestGetChat()
    {
        //arrange
       var controller = new ChatController(_fixture.Context);
        Chat chat = new Chat();
        
        chat.ChatId = 1;
        chat.UserOne = "ABCD";
        chat.UserTwo = "EFGH";

        //act
        var result = controller.GetChat(1).Result as OkObjectResult;
        var SavedChats = result.Value as Chat;

        //assert
        Assert.NotNull(result);
        Assert.Equal(chat.ToString(),SavedChats.ToString());
    }

    [Fact]
    public void TestGetMultipleChats()
    {
        //arrange
       var controller = new ChatController(_fixture.Context);
        Chat chat = new Chat();
        Chat chat2 = new Chat();
        IList<Chat> chats = new List<Chat>();

        chat.ChatId = 1;
        chat.UserOne = "ABCD";
        chat.UserTwo = "EFGH";

        chat.ChatId = 2;
        chat.UserOne = "ABCD";
        chat.UserTwo = "IJKL";

        chat.ChatId = 3;
        chat.UserOne = "ABCD";
        chat.UserTwo = "MNOP";

        //act
        chats.Add(chat);
        chats.Add(chat2);
        var result = controller.GetChats("ABCD").Result as OkObjectResult;
        var SavedChats = result.Value as IList<Chat>;

        //assert
        Assert.NotNull(result);
        Assert.Equal(chats.ToString(),SavedChats.ToString());
    }
}