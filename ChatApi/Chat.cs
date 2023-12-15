using System.ComponentModel.DataAnnotations;

namespace ChatApi;

public class Chat
{
    [Key]
    public int ChatId { get; set; }

    [Required]
    public string UserOne { get; set; }

    [Required]
    public string UserTwo { get;set; }

    public IList<ChatMessage> Messages { get;set; } = new List<ChatMessage>();
}
