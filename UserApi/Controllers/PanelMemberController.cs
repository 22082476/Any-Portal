using System.Text.Json;
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
        var result = _context.PanelMembers.Include((p) => p.Age).SingleOrDefaultAsync((p) => p.UserId.Equals(id));

        if(await result != null)
            return Ok(result);
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
        return Ok(panelMember); 
    }

[HttpPut]
public async Task<IActionResult> Put([FromServices] IHttpContextAccessor httpContextAccessor, [FromBody] PanelMember panelMember)
{
    if (httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("session-id", out string id))
    {
        var result = await _context.PanelMembers.SingleOrDefaultAsync(p => p.UserId.Equals(id));
    

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

    public async Task<IActionResult> Delete ([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        if (!httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("session-id", out string? id))
            return BadRequest();

        var deletedMembers =  await _context.PanelMembers.SingleOrDefaultAsync((p) => p.UserId.Equals(id));
        if (deletedMembers == null)
                return NotFound();

        if(await GetFromResearchApi  (id))
        {
            deletedMembers.UpdateToNull();
        }
        else
        {
            _context.Remove(deletedMembers);
        }

        try 
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return NoContent();
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


