using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdministratorController : ControllerBase
{
    private readonly UserContext _context;
    // private readonly ILog<AdminLogger> _logger;
    public AdministratorController (UserContext context)
    {
       _context = context;
    //    _logger = logger;
    //    , ILog<AdminLogger> logger
    }

    [HttpGet]
    [Route("Own/{userId}")]
    // public async Task<IActionResult> GetOwn ([FromServices] IHttpContextAccessor httpContextAccessor)
        public async Task<IActionResult> GetOwn (string userId)

    {
        // var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        if(userId != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result = await _context.Administrators.FirstOrDefaultAsync(p => p.UserId.Equals(userId));

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
        // var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        // {   
            // string tenantId = tenantIdClaim.Value;

            var result = _context.Administrators;

            if (result != null)
            {
                return Ok(result);
            }
            
        // }
    
        return NotFound();
}


    [HttpPost]
    // public async Task<IActionResult> Post ([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] Administrator administrator)
    public async Task<IActionResult> Post ([FromBody] Administrator administrator)
    {
        // var user = httpContextAccessor.HttpContext.User;
        
        // var admin = user.FindFirst("tid").Value;
        
        if(!_context.Administrators.Any((a) => a.UserId.Equals(administrator.UserId))){
            var add = _context.Administrators.AddAsync(administrator);

        try
        {
            await add;
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException e){
            Console.WriteLine(e);
            return StatusCode(500);
        }
            // _logger.Log(new LogMsg { ExecutedBy = admin, Source = "AdminController.Post()", Operation = "Toevoegen Beheerder", Msg = "Admin heeft beheerder toe gevoegd" });
            return Ok(administrator); 
        }

        
        return BadRequest("Account bestaat al");
    }

    [HttpPut]
    // public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] Administrator administrator)
    public async Task<IActionResult> Put([FromBody] Administrator administrator)
    {
       //var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result = await _context.Administrators.SingleOrDefaultAsync(p => p.UserId.Equals(administrator.UserId));

            if (result != null)
            {
                result = administrator;

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
    // public async Task<IActionResult> Delete ([FromServices] IHttpContextAccessor httpContextAccessor, string id)
    public async Task<IActionResult> Delete (string userId)
    {
        // var user = httpContextAccessor.HttpContext.User;
 
        // var tenantIdClaim = user.FindFirst("tid");
 
        // if (tenantIdClaim == null)
            // return BadRequest();

        if(userId != null)
        {   
            // string tenantId = tenantIdClaim.Value;
 
            var administrator =  await _context.Administrators.SingleOrDefaultAsync((p) => p.UserId.Equals(userId));

            if (administrator == null)
                return NotFound();

            _context.Administrators.Remove(administrator);

            try 
            {

            await _context.SaveChangesAsync();
            // _logger.Log(new LogMsg { ExecutedBy = tenantId, Source = "AdminController.Delete()", Operation = "Verwijderen Beheerder", Msg = $"Admin heeft beheerder {id} verwijderd" });

            return NoContent();
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
        return NotFound();
    }  
}