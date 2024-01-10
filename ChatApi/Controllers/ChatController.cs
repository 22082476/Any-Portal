using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetChat(int chatId)
    { var chat = _chatContext.Chats.SingleOrDefaultAsync(chat => chat.ChatId == chatId);

        if (await chat == null)
        {
            return NotFound("Er is geen chat gevonden");
        }

        return Ok(chat);
    }

    [HttpGet]
    [Route("GetUserChats/{UserId}")]
    public async Task<IActionResult> GetChats(string UserId)
    {
        var chats = _chatContext.Chats.Where(chat => chat.UserOne == UserId || chat.UserTwo == UserId);
        var IsFilled = await chats.AnyAsync();

        if (chats == null || !IsFilled)
        {
            return NotFound("Er is geen chat gevonden");
        }

        return Ok(chats);
    }

    [HttpGet]
    [Route("GetMessage/{ChatId}")]
    public async Task<IActionResult> GetMessages(int chatId)
    {
        var Messages = _chatContext.ChatMessages.Where(Messages => Messages.ChatId == chatId);
        var IsFilled = await Messages.AnyAsync();

        if (Messages == null || !IsFilled)
        {
            return NotFound("Er zijn geen berichten gevonden");
        }

        return Ok(Messages);
    }

    [HttpPost]
    [Route("SaveChat")]
    public async Task<IActionResult> Save(Chat chat)
    {
        if(CheckChat(chat)){
            _chatContext.Chats.Add(chat);
            var SaveContext =_chatContext.SaveChangesAsync();
            await SaveContext;
            return Ok("Chat toegevoegd");
        }
        return BadRequest("Foute request");
    }

    [HttpPut]
    [Route("UpdateChat")]
    public async Task<IActionResult> Update(Chat chat)
    {
        if(CheckChat(chat)){
            _chatContext.Chats.Update(chat);
            var SaveContext =_chatContext.SaveChangesAsync();
            await SaveContext;
            return Ok("Chat Geüpdated");  
        }
        return BadRequest("Foute request");
    }

    [HttpDelete] [Route("DeleteChat")]
    public async Task<IActionResult> Delete(Chat chat)
    {
        if(CheckChat(chat)){
        _chatContext.Chats.Remove(chat);
        var SaveContext =_chatContext.SaveChangesAsync();
        await SaveContext;
        return NoContent();
        }
        return BadRequest("Foute request");
    }

    [HttpPost]
    [Route("SendMessage")]
    public async Task<IActionResult> Post(ChatMessage chatMessage)
    {
        if(CheckMessages(chatMessage)){
            _chatContext.ChatMessages.Add(chatMessage);
            var SaveContext =_chatContext.SaveChangesAsync();
            await SaveContext;
            return Ok("Bericht verzonden");
        }
        return BadRequest("Foute request");
        
    }

    [HttpDelete]
    [Route("DeleteMessage")]
    public async Task<IActionResult> DeleteMessage(ChatMessage chatMessage)
    {
        if(CheckMessages(chatMessage)){
            _chatContext.ChatMessages.Remove(chatMessage);
            var SaveContext =_chatContext.SaveChangesAsync();
            await SaveContext;
            return NoContent();
        }
        return BadRequest("Foute request");
        
    }

    private bool CheckChat(Chat chat)
    {
        if(
            chat.ChatId == 0 ||
            chat.UserOne == null ||
            chat.UserTwo == null)
            {
            return false;
        }
        return true;
    }

    private bool CheckMessages(ChatMessage chatMessage)
    {
        if(
            chatMessage.MessageId == 0 ||
            chatMessage.ChatId == 0 ||
            chatMessage.Message == null ||
            chatMessage.SentFrom == null
        )
        {
            return false;
        }
        return true;
    }
}
