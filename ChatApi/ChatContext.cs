using Microsoft.EntityFrameworkCore;

namespace ChatApi;

public class ChatContext : DbContext
{
    public ChatContext(DbContextOptions<ChatContext> options) : base(options){}

    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get;set;}
}