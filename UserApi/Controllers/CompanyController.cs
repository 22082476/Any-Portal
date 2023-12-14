using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]/Company")]
public class CompanyController : ControllerBase
{
    private readonly UserContext _context;
    public CompanyController (UserContext context)
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

            var result = await _context.Companies.FirstOrDefaultAsync(p => p.UserId.Equals(tenantId));

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

            var result = _context.Companies.Select((c) => new { Email = c.Email, CompanyName = c.CompanyName, Location = c.Location, Website = c.Website, Description = c.Description });

            if (result != null)
            {
                return Ok(result);
            }
            
        }
    
        return NotFound();
}


    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] Company company)
    {
        if(!_context.Companies.Contains(company)){
            var add = _context.Companies.AddAsync(company);

        try
        {
            await add;
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException e){
            Console.WriteLine(e);
            return StatusCode(500);
        }
            return Ok(company); 
        }
        return BadRequest("Account bestaat al");
    }

[HttpPut]
public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] Company company)
{
       var user = httpContextAccessor.HttpContext.User;

        var tenantIdClaim = user.FindFirst("tid");

        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;

            var result = await _context.Companies.SingleOrDefaultAsync(p => p.UserId.Equals(tenantId));

            if (result != null)
            {
                result = company;

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
 
            var company =  await _context.Companies.SingleOrDefaultAsync((p) => p.UserId.Equals(tenantId));

            if (company == null)
                return NotFound();

            _context.Companies.Remove(company);

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
        


