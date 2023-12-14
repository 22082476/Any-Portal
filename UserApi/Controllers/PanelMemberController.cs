using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]/PanelMember")]
public class PanelMemberController : ControllerBase
{
    private readonly UserContext _context;
    public PanelMemberController (UserContext context)
    {
       _context = context;
    }

    [HttpGet]
    [Route("Own")]
    public async Task<IActionResult> Get ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
       var user = httpContextAccessor.HttpContext.User;

        var tenantIdClaim = user.FindFirst("tid");

        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;

            var result = _context.PanelMembers.Include((p) => p.Age).SingleOrDefaultAsync((p) => p.UserId.Equals(tenantId));

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
        if(!_context.PanelMembers.Contains(panelMember)){
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
    public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] PanelMember panelMember)
    {
        var user = httpContextAccessor.HttpContext.User;

            var tenantIdClaim = user.FindFirst("tid");

            if (tenantIdClaim != null)
            {   
                string tenantId = tenantIdClaim.Value;

                var result = await _context.PanelMembers.SingleOrDefaultAsync(p => p.UserId.Equals(tenantId));
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
    public async Task<IActionResult> Delete ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext.User;
 
        var tenantIdClaim = user.FindFirst("tid");
 
        if (tenantIdClaim != null)
        {   
            string tenantId = tenantIdClaim.Value;
 
            var member =  await _context.PanelMembers.Include((m) => m.Age).SingleOrDefaultAsync((p) => p.UserId.Equals(tenantId));

            if (member != null){
                

                if(await GetFromResearchApi  (tenantId))
                {
                    member.UpdateToNull();
                }
                else
                {
                    _context.Remove(member);
                }

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
        }
        return NotFound();
    }


    private static async Task<bool> GetFromResearchApi (string id)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Voeg eventuele headers toe (optioneel)
                client.DefaultRequestHeaders.Add("Cookie", id);

                string apiUrl = "https://localhost:3004/"; //aanvullen

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<bool>(responseBody);
                }
                else
                {
                    Console.WriteLine("Fout: " + response.StatusCode);
                    return true;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Er is een fout opgetreden bij het uitvoeren van het HTTP-verzoek: " + e.Message);
                return true;
            }
        }
    }
}


