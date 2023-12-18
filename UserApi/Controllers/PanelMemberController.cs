using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PanelMemberController : ControllerBase
{
    private readonly UserContext _context;
    private readonly IResearchApiService _service;
    public PanelMemberController (UserContext context, IResearchApiService service)
    {
       _context = context;
       _service = service;

    }

    [HttpGet]
    [Route("Own/{userId}")]
    // public async Task<IActionResult> Get ([FromServices] IHttpContextAccessor httpContextAccessor)
    public async Task<IActionResult> GetOwn (string userId)
    {
    //    var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        if (userId != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result =  await _context.PanelMembers.Include((p) => p.Age).SingleOrDefaultAsync((p) => p.UserId.Equals(userId));

            if (result != null)
            {
                return Ok(result);
            }
        }
    
        return NotFound();
    }

    [HttpGet]
    // public async Task<IActionResult> GetAll ([FromServices] IHttpContextAccessor httpContextAccessor)
    public async Task<IActionResult> GetAll ()
    {
    //    var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result = _context.PanelMembers.Include((p) => p.Age).Select((p) => new { FirstName = p.FirstName, LastName = p.FirstName,  Email = p.Email, PhoneNumber = p.PhoneNumber, Age = p.Age, Preferred_contact = p.Preferred_contact, PostalCode = p.PostalCode, Availability = p.Availability});

                if (result != null)
                {
                    return Ok(result);
                }
        }
    
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] PanelMember panelMember)
    {
        if(!_context.PanelMembers.Any((p) => p.UserId.Equals(panelMember.UserId))){

            panelMember.Age = await _context.AgeRanges.SingleAsync((a) => a.RangeName.Equals(panelMember.Age.RangeName));
    
            var add = _context.PanelMembers.AddAsync(panelMember);

        try
        {
            await add;
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException e){
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok(panelMember); 

        }
        return BadRequest("Account bestaat al");        
    }

    [HttpPut]
    // public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] PanelMember panelMember)
    public async Task<IActionResult> Put([FromBody] PanelMember panelMember)
    {
        // var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result = await _context.PanelMembers.SingleOrDefaultAsync(p => p.UserId.Equals(panelMember.UserId));

            if (result != null)
            {
                result = panelMember;
            
                try
                {
                    await _context.SaveChangesAsync();

                    return Ok(result);
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

    [HttpDelete]
    [Route("{userId}")]
    // public async Task<IActionResult> Delete ([FromServices] IHttpContextAccessor httpContextAccessor)
    public async Task<IActionResult> Delete (string userId)

    {
        // var user = httpContextAccessor.HttpContext.User;
 
        // var tenantIdClaim = user.FindFirst("tid");
 
        // if (tenantIdClaim != null)
        if (userId != null)
        {   
            // string tenantId = tenantIdClaim.Value;
 
            var member =  await _context.PanelMembers.Include((m) => m.Age).SingleOrDefaultAsync((p) => p.UserId.Equals(userId));

            if (member != null){
            
            var deletionAllowed = await _service.GetFromResearchApi  (userId);

                switch (deletionAllowed){
                    case true :
                        member.UpdateToNull();
                        break;
                    case false:
                        _context.Remove(member);
                        break;
                    default:
                        return StatusCode(500);
                        break;
                }

                try 
                {
                    await _context.SaveChangesAsync();

                    if (deletionAllowed == false)
                        return NoContent();
                        
                        return Ok(member);
                    
                    
                }
                catch(DbUpdateException e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500);
                }
            }
        }
        return NotFound();
    }
}


