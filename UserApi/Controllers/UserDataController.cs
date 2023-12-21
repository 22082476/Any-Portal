using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDataController : ControllerBase
{
    private readonly UserContext _context;
    
    public UserDataController (UserContext context)
    {
       _context = context;
    }

    [HttpGet]
    [Route("Names")]
    public async Task<IActionResult> GetNames ()
    {
        var result = _context.PanelMembers.Select((p) => new { UserId = p.UserId, FirstName = p.FirstName, LastName = p.LastName });

        if(result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpGet]
    [Route("Ages/{AgeId}")]
    public async Task<IActionResult> GetAge (int AgeId)
    {
        if (AgeId != null)
        {
            var result =  _context.AgeRanges.SingleOrDefault((r) => r.AgeId == AgeId);

            if(result != null)
            {
                return Ok(result);
            }
                

        }

        return NotFound();
        
    }

    [HttpGet]
    [Route("Ages")]
    public async Task<IActionResult> GetAges ()
    {
            var result =  _context.AgeRanges;

            if(result != null)
                return Ok(result);

        return NotFound();
    }
}