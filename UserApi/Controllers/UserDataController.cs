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
    public async Task<IActionResult> GetNames ()
    {
        var result = _context.PanelMembers.Select((p) => new { FirstName = p.FirstName, LastName = p.LastName });

        if(result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpGet]
    [Route("Ages/{rangeName}")]
    public async Task<IActionResult> GetAges (string rangeName)
    {
        if (rangeName != null)
        {
            var result =  _context.AgeRanges.SingleOrDefault((r) => r.RangeName.Equals(rangeName));

            if(result != null)
                return Ok(result);

        }

        return NotFound();
        
    }
}


