using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]/Administrator")]
public class AdministratorController : ControllerBase
{
    private readonly UserContext _context;
    public AdministratorController (UserContext context)
    {
       _context = context;
    }

    [HttpGet]
    [Route("Own")]
    public async Task<IActionResult> GetOwn ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext.User;

        var tenantIdClaim = user.FindFirst("tid");

        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;

            var result = await _context.Administrators.FirstOrDefaultAsync(p => p.UserId.Equals(tenantId));

            if (result != null)
            {
                return Ok(result);
            }
        }
    
    return NotFound();
}

    [HttpGet]
    public async Task<IActionResult> GetAll ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext.User;

        var tenantIdClaim = user.FindFirst("tid");

        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;

            var result = _context.Administrators;

            if (result != null)
            {
                return Ok(result);
            }
            
        }
    
        return NotFound();
}


    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] Administrator administrator)
    {
        if(!_context.Administrators.Contains(administrator)){
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
            return Ok(administrator); 
        }
        return BadRequest("Account bestaat al");
    }

[HttpPut]
public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] Administrator administrator)
{
       var user = httpContextAccessor.HttpContext.User;

        var tenantIdClaim = user.FindFirst("tid");

        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;

            var result = await _context.Administrators.SingleOrDefaultAsync(p => p.UserId.Equals(tenantId));

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
    public async Task<IActionResult> Delete ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext.User;
 
        var tenantIdClaim = user.FindFirst("tid");
 
        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;
 
            var administrator =  await _context.Administrators.SingleOrDefaultAsync((p) => p.UserId.Equals(tenantId));

            if (administrator == null)
                return NotFound();

            _context.Administrators.Remove(administrator);

            try 
            {

            await _context.SaveChangesAsync();

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