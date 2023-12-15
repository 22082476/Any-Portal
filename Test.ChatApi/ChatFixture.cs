using ChatApi;
using Microsoft.EntityFrameworkCore;
public class ChatFixture : ChatContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new ChatContext(options);
        context.Chats.AddRange(
                new Chat {ChatId = 1, UserOne = "ABCD", UserTwo = "EFGH"},
                new Chat {ChatId = 2, UserOne = "ABCD", UserTwo = "IJKL"},
                new Chat {ChatId = 3, UserOne = "ABCD", UserTwo = "MNOP"}
            );
        context.SaveChanges();
    }
}
