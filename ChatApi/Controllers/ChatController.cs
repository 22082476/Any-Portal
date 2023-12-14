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

    [HttpGet]
    [Route("GetChat/{ChatId}")]
    public IActionResult Get(int chatId)
    { var chat = _chatContext.Chats.Where(chat => chat.ChatId == chatId).ToList();

        if (chat == null || !chat.Any())
        {
            return NotFound();
        }

        return Ok(chat);
    }

    [HttpGet]
    [Route("GetUserChats/{UserId}")]
    public IActionResult Get(string UserId)
    {
        var chats = _chatContext.Chats.Where(chat => chat.UserOne == UserId || chat.UserTwo == UserId).ToList();

        if (chats == null || !chats.Any())
        {
            return NotFound();
        }

        return Ok(chats);
    }

    [HttpGet]
    [Route("GetMessage/{ChatId}")]
    public IActionResult GetMessages(int chatId)
    {
        var Messages = _chatContext.ChatMessages.Where(Messages => Messages.ChatId == chatId);

        if (Messages == null || !Messages.Any())
        {
            return NotFound();
        }

        return Ok(Messages);
    }

    [HttpPost]
    [Route("SaveChat")]
    public IActionResult Save(Chat chat)
    {
        if(CheckChat(chat)){
            _chatContext.Chats.Add(chat);
            _chatContext.SaveChanges();
            return Ok();
        }
        return BadRequest();
    }

    [HttpPut]
    [Route("UpdateChat")]
    public IActionResult Update(Chat chat)
    {
        if(CheckChat(chat)){
            _chatContext.Chats.Update(chat);
            _chatContext.SaveChanges();
            return Ok();  
        }
        return BadRequest();
    }

    [HttpDelete] [Route("DeleteChat")]
    public IActionResult Delete(Chat chat)
    {
        _chatContext.Chats.Remove(chat);
        _chatContext.SaveChanges();
        return Ok();
    }

    [HttpPost]
    [Route("SendMessage")]
    public IActionResult Post(ChatMessage chatMessage)
    {
        if(CheckMessages(chatMessage)){
            _chatContext.ChatMessages.Add(chatMessage);
            _chatContext.SaveChanges();
            return Ok();
        }
        return BadRequest();
        
    }

    [HttpDelete]
    [Route("DeleteMessage")]
    public IActionResult Delete(ChatMessage chatMessage)
    {
        if(CheckMessages(chatMessage)){
            _chatContext.ChatMessages.Remove(chatMessage);
            _chatContext.SaveChanges();
            return Ok();
        }
        return BadRequest();
        
    }

    private bool CheckChat(Chat chat)
    {
        if(
            chat.UserOne == null ||
            chat.UserTwo == null ||
            chat.Messages == null
        )
        {
            return false;
        }
        return true;
    }

    private bool CheckMessages(ChatMessage chatMessage)
    {
        if(
            chatMessage.Message == null ||
            chatMessage.SentFrom == null
        )
        {
            return false;
        }
        return true;
    }
}
