using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly UserContext _context;
    public CompanyController (UserContext context)
    {
       _context = context;
    }

    [HttpGet]
    [Route("{userId}")]
    // public async Task<IActionResult> GetOwn ([FromServices] IHttpContextAccessor httpContextAccessor)
    public async Task<IActionResult> GetOwn (string userId)
    {
        // var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        {   
            // string tenantId = tenantIdClaim.Value;

            var result = await _context.Companies.FirstOrDefaultAsync(p => p.UserId.Equals(userId));

            if (result != null)
            {
                return Ok(result);
            }
    }
    
    return NotFound();
    }

    [HttpGet]
    // public async Task<IActionResult> GetAll ([FromServices] IHttpContextAccessor httpContextAccessor)
    public async Task<IActionResult> GetAll ([FromQuery] bool validationFilter)
    {
        // var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        {   
            var resultQuery = _context.Companies.AsQueryable();
            // string tenantId = tenantIdClaim.Value;
            if(validationFilter)
            {
                resultQuery = resultQuery.Where((c) => !c.IsValid);
            }
            
            
              var result = resultQuery.Select((c) => new { UserId = c.UserId, Email = c.Email, CompanyName = c.CompanyName, Location = c.Location, Website = c.Website, Description = c.Description });
            

            if (result != null)
            {
                return Ok(result);
            }
            
        }
    
        return NotFound();
    }
    


    [HttpPost]
    // public async Task<IActionResult> Post ([FromBody] Company company)
    public async Task<IActionResult> Post ([FromBody] Company company)
    {
        if(!_context.Companies.Any((c) => c.UserId.Equals(company.UserId))){
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
    // public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] Company company)
    public async Task<IActionResult> Put([FromBody] Company company)
    {
    //    var user = httpContextAccessor.HttpContext.User;

        // var tenantIdClaim = user.FindFirst("tid");

        // if (tenantIdClaim != null)
        
      
            // string tenantId = tenantIdClaim.Value;

        _context.Companies.Update(company);


        try
        {
            await _context.SaveChangesAsync();

            return Ok(company);
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
        if(userId != null)
        {   
            // string tenantId = tenantIdClaim.Value;
 
            var company =  await _context.Companies.SingleOrDefaultAsync((p) => p.UserId.Equals(userId));

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