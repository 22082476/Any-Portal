using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class MedicalController : ControllerBase
{
    private readonly MedicalContext _context;
    public MedicalController (MedicalContext context)
    {
       _context = context;
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetOwn (string userId)
    {
        List<RequestModel> list = [];
        
        var result = await _context.Disabilities
        .Where(a => a.UserId.Equals(userId))
        .ToListAsync();


            if (result != null)
            {
                foreach(var disability in result)
                {
                    var tools = await _context.Tools.Where((t) => t.Dcode == disability.Dcode).ToListAsync();

                    list.Add(new RequestModel {Disability = disability, Tools = tools});
                }

                return Ok(list);
            }

        return NotFound();   
    }

[HttpPost]
public async Task<IActionResult> Post([FromBody] List<RequestModel> requests)
{
    foreach (var request in requests)
    {
        if (await _context.Disabilities.AnyAsync(d => d.UserId.Equals(request.Disability.UserId) && d.Type.Equals(request.Disability.Type)))
        {
            return BadRequest($"Beperking bestaat al voor deze user met dit type");
        }

        // Voeg de tools toe aan de database als ze nog niet bestaan
        foreach (var tool in request.Tools)
        {
            tool.Dcode = request.Disability.Dcode;
            tool.UserId = request.Disability.UserId;

            if (! await _context.Tools.AnyAsync(t => t.UserId.Equals(tool.UserId) && t.Name.Equals(tool.Name) && t.Dcode == tool.Dcode))
            {
                _context.Tools.Add(tool);
            }
        }

        var add =  await _context.Disabilities.AddAsync(request.Disability);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }

    // Als alle Disability-objecten succesvol zijn toegevoegd
    return Ok(requests);
}

[HttpPut]
public async Task<IActionResult> Put([FromBody] RequestModel request)
{
    _context.Update(request.Disability);

    var existingTools = await _context.Tools
        .Where(t => t.Dcode == request.Disability.Dcode)
        .ToListAsync();

    foreach (var existingTool in existingTools)
    {
        var matchingTool = request.Tools.FirstOrDefault(t => t.Id == existingTool.Id);

        if (matchingTool != null)
        {
            _context.Entry(existingTool).CurrentValues.SetValues(matchingTool);
        }
        else
        {
            _context.Tools.Remove(existingTool);
        }
    }

    foreach (var tool in request.Tools)
    {
        tool.Dcode = request.Disability.Dcode;
        tool.UserId = request.Disability.UserId;

        var existingTool = await _context.Tools.FindAsync(tool.Id);

        if (existingTool != null)
        {
            _context.Entry(existingTool).CurrentValues.SetValues(tool);
        }
        else
        {
            _context.Tools.Add(tool);
        }
    }

    try
    {
        await _context.SaveChangesAsync();

        return Ok(new { Disability = request.Disability, Tools = request.Tools });
    }
    catch (DbUpdateException e)
    {
        Console.WriteLine(e);
        return BadRequest();
    }
}



    [HttpDelete]
    [Route("{userId}")]
    public async Task<IActionResult> DeleteAll (string userId)
    {

 
        var result = _context.Disabilities.Where((d) => d.UserId.Equals(userId));
        var tools = _context.Tools.Where((t) => t.UserId.Equals(userId));


        if (result == null)
            return NotFound();

        foreach(var item in result)
        {
            _context.Remove(item);
        }

        if(tools != null)
        {
            foreach(var tool in tools)
            {
                _context.Remove(tool);
            }
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