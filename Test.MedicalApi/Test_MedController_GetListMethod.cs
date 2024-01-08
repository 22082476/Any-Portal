using MedicalApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.MedicalApi;

 public class Test_MedController_GetListMethod
{
    [Fact]
    public async Task Get_ReturnsListOfDisabilities()
    {
        // Arrange
        
        // Create options for an in-memory database.
        var options = new DbContextOptionsBuilder<DisabilityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Using statement ensures proper disposal of the context after the block.
        using (var context = new DisabilityDbContext(options))
        {
            // Add sample disabilities to the in-memory database.
            context.Disabilities.AddRange(new List<Disability>
            {
                new Disability { UserId = "user1", Type = "Fysiek", Name = "Amputatie", Tool = "Arm extensie" },
                new Disability { UserId = "user2", Type = "Visueel", Name = "Blind", Tool = "Voorlees app" },
            });

            context.SaveChanges(); // Save changes to the in-memory database.
        }

        // Create a new context for querying the in-memory database.
        using (var context = new DisabilityDbContext(options))
        {
            var controller = new MedicalController(context);

            // Act
            var result = await controller.Get(); // Call the Get method in the controller.

            // Assert
            Assert.IsType<OkObjectResult>(result); // Assert that the result is an OkObjectResult.

            var okResult = result as OkObjectResult;
            var returnedDisabilities = okResult.Value as List<Disability>;

            Assert.NotNull(returnedDisabilities); // Assert that the returned list is not null.
            Assert.Equal(2, returnedDisabilities.Count); // Assuming two disabilities in Arrange.
        }
    }
}

    public class MedicalController : ControllerBase
{
    private readonly DisabilityDbContext _context;
    
    public MedicalController(DisabilityDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var disabilities = await _context.Disabilities.ToListAsync();
        
        // Return an OkObjectResult with the provided list of disabilities.
        return Ok(disabilities);  
    }

    [HttpGet("Dcode")]
    [ProducesResponseType(typeof(Disability), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByDcode(int Dcode)
    {
        var disability = await _context.Disabilities.FindAsync(Dcode);
        return disability == null ? NotFound() : Ok(disability);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Disability disability)
    {
        await _context.Disabilities.AddAsync(disability);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetByDcode), new {dcode = disability.Dcode}, disability);
    }

    [HttpPut("{Dcode}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int Dcode, Disability disability)
    {
        if (Dcode != disability.Dcode) return BadRequest();

        _context.Entry(disability).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{Dcode}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int Dcode)
    {
        var disabilityToDelete = await _context.Disabilities.FindAsync(Dcode);
        if (disabilityToDelete == null) return NotFound();

        _context.Disabilities.Remove(disabilityToDelete);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}