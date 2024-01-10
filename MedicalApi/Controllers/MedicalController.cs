using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Controllers;

// ApiController attribute indicates that this class is an API controller.
// Route attribute sets the base route for actions in this controller.
[ApiController]
[Route("[controller]")]
public class MedicalController : ControllerBase
{
    // Private field to hold an instance of DisabilityDbContext, which represents the database context.
    private readonly DisabilityDbContext _context;
    
    // Constructor to inject DisabilityDbContext dependency.
    public MedicalController(DisabilityDbContext context) => _context = context;

    // GET: Returns a list of all disabilities.
    [HttpGet]
    public async Task<IEnumerable<Disability>> Get()
    {
        // Retrieve all disabilities from the database asynchronously and convert them to a list.
        return await _context.Disabilities.ToListAsync();   
    }

    // GET by Dcode: Returns a specific disability by its Dcode.
    [HttpGet("Dcode")]
    [ProducesResponseType(typeof(Disability), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByDcode(int Dcode)
    {
        var disability = await _context.Disabilities.FindAsync(Dcode);
        return disability == null ? NotFound() : Ok(disability);
    }

    // POST: Creates a new disability.
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Disability disability)
    {
        await _context.Disabilities.AddAsync(disability);
        await _context.SaveChangesAsync();

        // Returns 201 Created status with the location of the new resource.
        return CreatedAtAction(nameof(GetByDcode), new {dcode = disability.Dcode}, disability);
    }

    // PUT: Updates an existing disability by Dcode.
    [HttpPut("{Dcode}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int Dcode, Disability disability)
    {
        // Checks if the provided Dcode matches the Dcode in the payload.
        if (Dcode != disability.Dcode) return BadRequest();

        _context.Entry(disability).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        // Returns 204 No Content status for a successful update.
        return NoContent();
    }

    // DELETE: Deletes a disability by Dcode.
    [HttpDelete("{Dcode}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int Dcode)
    {
        var disabilityToDelete = await _context.Disabilities.FindAsync(Dcode);
        if (disabilityToDelete == null) return NotFound();

        _context.Disabilities.Remove(disabilityToDelete);
        await _context.SaveChangesAsync();

        // Returns 204 No Content status for a successful deletion.
        return NoContent();
    }
    
}
