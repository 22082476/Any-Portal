using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
public class ChatWithMessageFixture : ChatContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new ChatContext(options);
        context.ChatMessages.AddRange(
                new ChatMessage {MessageId = 1, ChatId = 1, Message = "hey geert", SentFrom = "ABCD", DateTime = new DateTime(2023, 4, 15, 13, 30, 0)}
        );
        context.SaveChanges();
    }
}