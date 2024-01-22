using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet]
    [Route("/Role/{userId}")]
    public async Task<IActionResult> GetRole (string userId)
    {
        if(userId != null)
        {   
            if(await _context.PanelMembers.AnyAsync((a) => a.UserId.Equals(userId)))
                return Ok("PanelMember");

            if(await _context.Companies.AnyAsync((a) => a.UserId.Equals(userId)))
                return Ok("Company");

            if( await _context.Administrators.AnyAsync((a) => a.UserId.Equals(userId)))
            {
                
               if(_context.Administrators.Single((a) => a.UserId.Equals(userId)).IsAdmin)
                    return Ok("Admin"); 
                return Ok("Administrator");
            }

            return NotFound();    
        }

        return BadRequest();
    }
}