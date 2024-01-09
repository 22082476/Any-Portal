using System.ComponentModel.DataAnnotations;

namespace ChatApi;

public class ChatMessage
{
    [Key]
    public int MessageId { get;set; }
    [Required]
    public string SentFrom{ get;set; }

    [Required]
    public string Message { get;set; }

    [Required]
    public DateTime DateTime { get;set; }

    [Required]
    public int ChatId { get;set; }
}