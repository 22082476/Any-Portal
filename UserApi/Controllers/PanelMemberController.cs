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
    [Route("{userId}")]
    // public async Task<IActionResult> Get ([FromServices] IHttpContextAccessor httpContextAccessor)
    public async Task<IActionResult> GetOwn (string userId)
    {
    //    var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        if (userId != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result = await _context.PanelMembers.SingleOrDefaultAsync((p) => p.UserId.Equals(userId));
            

            if (result != null )
            {
                var ageRange = await _context.AgeRanges.SingleOrDefaultAsync((a) => a.AgeId == result.AgeId);

                var caretaker = await _context.Caretakers.SingleOrDefaultAsync((c) => c.CaretakerId == result.CaretakerId);

                if(ageRange != null){
                    return Ok(new {PanelMember = result, AgeRange = ageRange, Caretaker = caretaker});
                }
                return NotFound("AgeRange niet gevonden");

            }
        }
    
        return NotFound("PanelLid niet gevonden");
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

            var result = _context.PanelMembers.Select((p) => new { UserId = p.UserId, FirstName = p.FirstName, LastName = p.FirstName,  Email = p.Email, PhoneNumber = p.PhoneNumber, AgeId = p.AgeId, Preferred_contact = p.Preferred_contact, PostalCode = p.PostalCode, Availability = p.Availability, Caretaker = p.CaretakerId == null});

                if (result != null)
                {
                    return Ok(result);
                }
        }
    
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] RequestModel request)
    {
        if(!_context.PanelMembers.Any((p) => p.UserId.Equals(request.PanelMemberNew.UserId)) 

        || !_context.Caretakers.Any((p) => p.CaretakerId.Equals(request.Caretaker.CaretakerId))){

        if(!await _context.AgeRanges.AnyAsync((a) => a.AgeId == request.PanelMemberNew.AgeId))
            return BadRequest("AgeRange niet gevonden");

        var add = _context.PanelMembers.AddAsync(request.PanelMemberNew);

        if(request.Caretaker != null){
            var add2 =  await _context.Caretakers.AddAsync(request.Caretaker);
        }

        try
        {
            await add;
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException e){
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok(new { PanelMember = request.PanelMemberNew, Caretaker = request.Caretaker}); 

        }
        return BadRequest("Account bestaat al");        
    }

    [HttpPut]
    // public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] PanelMember panelMember)
    public async Task<IActionResult> Put([FromBody] RequestModelPut request)
    {
        // var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        if(!await _context.AgeRanges.AnyAsync((a) => a.AgeId == request.PanelMemberNew.AgeId ))
            return NotFound("AgeRange niet gevonden");
         
            // string tenantId = tenantIdClaim.Value;

        if(! await _context.PanelMembers.AnyAsync(p => p.UserId == request.PanelMemberCurrent.UserId))
        {
            return NotFound("PanelMember niet gevonden");
        }else
        {
           
           if(request.PanelMemberNew.CaretakerId == null)
           {
                // _context.PanelMembers.Update(request.PanelMember);

                if(request.PanelMemberCurrent.CaretakerId != null)
                {
                    _context.Remove(_context.Caretakers.Single((c) => c.CaretakerId == request.PanelMemberCurrent.CaretakerId));
                }
           }else
           {
                if(request.PanelMemberCurrent.CaretakerId != null)
                {
                    if(request.Caretaker != null)
                    {
                       request.Caretaker.CaretakerId = request.PanelMemberCurrent.CaretakerId;
                       _context.Update(request.Caretaker);
                    }
                    
                }else
                {
                    if(request.Caretaker != null){
                        _context.Caretakers.Add(request.Caretaker);
                    }
                }
           }
            
            _context.Update(request.PanelMemberNew);
            // _context.Remove(request.PanelMember);
            // _context.SaveChanges();

            // _context.Add(request.PanelMember);

        }
   
        try
        {
            await _context.SaveChangesAsync();

            return Ok(new { PanelMember = request.PanelMemberNew, Caretaker = request.Caretaker});
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
                    
            return BadRequest();
        }
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
 
            var member =  await _context.PanelMembers.SingleOrDefaultAsync((p) => p.UserId.Equals(userId));

            if (member != null){
            
            var deletionAllowed = await _service.GetFromResearchApi  (userId);
            var caretaker = await _context.Caretakers.SingleOrDefaultAsync((c) => c.CaretakerId == member.CaretakerId);
            var HasCareTaker = caretaker != null;

                if (deletionAllowed){
                        member.UpdateToNull();

                        if(HasCareTaker)
                        _context.Caretakers.Remove(caretaker!);

                        _context.Update(member);

                }else if(!deletionAllowed)
                {
                    _context.Remove(member);

                    if(HasCareTaker)
                            _context.Remove(caretaker);

                        
                }
                

                try 
                {
                    await _context.SaveChangesAsync();

                    if (!deletionAllowed)
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


