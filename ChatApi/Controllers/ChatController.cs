using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;

    private readonly ChatContext _chatContext;

    public ChatController(ILogger<ChatController> logger, ChatContext chatContext)
    {
        _logger = logger;
        _chatContext = chatContext;
    }

    [HttpGet("{chatId}", Name = "GetChat")]
    public IActionResult Get(int chatId)
    {
        var chat = _chatContext.Chats.Where(chat => chat.ChatId == chatId).ToList();

        if (chat == null || !chat.Any())
        {
            return NotFound();
        }

        return Ok(chat);
    }

    [HttpGet("{UserId}", Name = "GetUser")]
    public IActionResult Get(string UserId)
    {
        var chats = _chatContext.Chats.Where(chat => chat.UserOne == UserId || chat.UserTwo == UserId).ToList();

        if (chats == null || !chats.Any())
        {
            return NotFound();
        }

        return Ok(chats);
    }

    [HttpGet("{chatId}", Name = "GetAllChat")]
    public IActionResult Get(int chatId)
    {
        var chats = _chatContext.Chats.Where(chat => chat.ChatId == chatId).ToList();

        if (chats == null || !chats.Any())
        {
            return NotFound();
        }

        return Ok(chats);
    }

    [HttpPost( Name = "AddChat")]
    public IActionResult Post(Chat chat)
    {
        
        return Ok();
    }

    [HttpPost( Name = "SendMessage")]
    public IActionResult Post(ChatMessage chatMessage)
    {
        
        return Ok();
    }
}
