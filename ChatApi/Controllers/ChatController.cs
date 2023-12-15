using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ChatContext _chatContext;

    public ChatController(ChatContext chatContext)
    {
        _chatContext = chatContext;
    }

    [HttpGet]
    [Route("GetChat/{ChatId}")]
    public IActionResult GetChat(int chatId)
    { var chat = _chatContext.Chats.SingleOrDefault(chat => chat.ChatId == chatId);

        if (chat == null)
        {
            return NotFound("Er is geen chat gevonden");
        }

        return Ok(chat);
    }

    [HttpGet]
    [Route("GetUserChats/{UserId}")]
    public IActionResult GetChats(string UserId)
    {
        var chats = _chatContext.Chats.Where(chat => chat.UserOne == UserId || chat.UserTwo == UserId).ToList();

        if (chats == null || !chats.Any())
        {
            return NotFound("Er is geen chat gevonden");
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
            return NotFound("Er zijn geen berichten gevonden");
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
            return Ok("Chat toegevoegd");
        }
        return BadRequest("Foute request");
    }

    [HttpPut]
    [Route("UpdateChat")]
    public IActionResult Update(Chat chat)
    {
        if(CheckChat(chat)){
            _chatContext.Chats.Update(chat);
            _chatContext.SaveChanges();
            return Ok("Chat Geüpdated");  
        }
        return BadRequest("Foute request");
    }

    [HttpDelete] [Route("DeleteChat")]
    public IActionResult Delete(Chat chat)
    {
        _chatContext.Chats.Remove(chat);
        _chatContext.SaveChanges();
        return Ok("Chat toegevoegd");
    }

    [HttpPost]
    [Route("SendMessage")]
    public IActionResult Post(ChatMessage chatMessage)
    {
        if(CheckMessages(chatMessage)){
            _chatContext.ChatMessages.Add(chatMessage);
            _chatContext.SaveChanges();
            return Ok("Bericht verzonden");
        }
        return BadRequest("Foute request");
        
    }

    [HttpDelete]
    [Route("DeleteMessage")]
    public IActionResult Delete(ChatMessage chatMessage)
    {
        if(CheckMessages(chatMessage)){
            _chatContext.ChatMessages.Remove(chatMessage);
            _chatContext.SaveChanges();
            return Ok("Bericht verwijderd");
        }
        return BadRequest("Foute request");
        
    }

    private bool CheckChat(Chat chat)
    {
        if(
            chat.UserOne == null ||
            chat.UserTwo == null ||
            chat.Messages == null)
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
