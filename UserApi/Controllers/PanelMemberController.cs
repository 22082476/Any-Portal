using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]/PanelMember")]
public class UserApiController : ControllerBase
{
    private readonly UserContext _context;
    public UserApiController (UserContext context)
    {
       _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
       if(httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("session-id", out string id))
       {
        var result = _context.PanelMembers.SingleOrDefaultAsync((p) => p.UserId.Equals(id));

        if(await result != null)
            return Ok(result);
       }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post (PanelMember panelMember)
    {
        var add = _context.PanelMembers.AddAsync(panelMember);

        try{
        await add;
        await _context.SaveChangesAsync();
        }
        catch(DbUpdateException e){
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok(panelMember); 
    }

    [HttpPut]
public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, PanelMemberNullable panelMember)
{
    if (httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("session-id", out string id))
    {
        var result = await _context.PanelMembers.FirstOrDefaultAsync(p => p.UserId.Equals(id));
    

        if (result != null)
        {
            // Bijwerken van de eigenschappen van het gevonden object met nieuwe waarden
            if(panelMember.FirstName)
            result.FirstName = panelMember.FirstName.Value;
            result.LastName = panelMember.LastName.Value;
            result.Email = panelMember.Email.Value;
            result.PhoneNumber = panelMember.PhoneNumber.Value;
            // ... andere eigenschappen bijwerken zoals nodig

            try
            {
                await _context.SaveChangesAsync();
                return Ok(result); // Return updated object
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }

    return NotFound();
}

}
