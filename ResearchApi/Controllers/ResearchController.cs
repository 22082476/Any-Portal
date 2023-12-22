using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ResearchApi;

[ApiController]
[Route("[controller]")]
public class ResearchController : ControllerBase{
    private readonly ResearchContext _context;

    public ResearchController(ResearchContext context){
        _context = context;
    }


    [HttpGet("{researchId}")]
    public IActionResult GetResearch(int researchId){
    var result = _context.Research.SingleOrDefault(s => s.Rcode == researchId);
       
        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }
 

    [HttpGet("GetAllResearch")]
    public IActionResult GetAllResearch(){
    var result = _context.Research.ToList();

        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }


    [HttpPost("CreateResearch")]
    public IActionResult CreateResearch([FromBody] Research research){
        if(research == null){
            return BadRequest();
        }

        try{
            research.Active = false;
            _context.Research.Add(research);
            _context.SaveChanges();
            return Ok(new { Message = "Research created successfully", ResearchId = research.Rcode });
        }
    
        catch (Exception ex){
            return BadRequest(new { Message = "Failed to create research", Error = ex.Message });
        }
    }


    [HttpPost("CreateParticipant")]
    public IActionResult CreateParticipant(Participant participant){
    
        if(participant == null){
            return BadRequest();
        }

        try{
            _context.Participants.Add(participant);
            _context.SaveChanges();
            return Ok(new { Message = "Participant added successfully", ResearchId = participant.UserId});
        }

        catch (Exception ex){
            return BadRequest(new { Message = "Failed to create Participant", Error = ex.Message });
        }
    }


    [HttpPost("CreateAllowed_AgeRange")]
    public IActionResult CreateAllowed_AgeRange(Allowed_AgeRange allowed_AgeRange){

        if(allowed_AgeRange == null){
        return BadRequest();
        }

        try{
            _context.allowed_AgeRanges.Add(allowed_AgeRange);
            _context.SaveChanges();
            return Ok(new { Message = "Agerange created successfully", ResearchId = allowed_AgeRange.Allowed_AgeRangeId});
        }

      
        catch (Exception ex){
            return BadRequest(new { Message = "Failed to create AgeRange", Error = ex.Message });
        }
    }
    

    [HttpPost("PostalcodeRange")]
    public IActionResult CreatePostalcodeRange(PostalCodeRange postalCodeRange){

        if(postalCodeRange == null){
        return BadRequest();
        }
          
        try{    
            _context.PostalCodeRanges.Add(postalCodeRange);
            _context.SaveChanges();
            return Ok(new { Message = "PostalcodeRange created successfully", ResearchId = postalCodeRange.Id});
        }
        catch (Exception ex){
            return BadRequest(new { Message = "Failed to create PostalcodeRange", Error = ex.Message });
        }
    }


    [HttpDelete]
    public IActionResult DeleteResearch(int id){
        var research = _context.Research.Find(id);
        if (research == null){
            return NotFound();
        }

        _context.Research.Remove(research);
        
        try{
        _context.SaveChanges();

            return NoContent();
        }
        
        catch(DbUpdateException e){
            System.Console.WriteLine(e);
            return BadRequest();
        }
    }
   

   [HttpPut("Update")]
    public IActionResult UpdateResearch(int id, Research updatedResearch){
        var existingResearch = _context.Research.FirstOrDefault(r => r.Rcode == id);

        if (existingResearch == null){
        return NotFound();
        }

        if (existingResearch.Active){
            existingResearch.Title = updatedResearch.Title;
            existingResearch.Compensation = updatedResearch.Compensation;
            existingResearch.Type_Research = updatedResearch.Type_Research;
            existingResearch.Link_Research = updatedResearch.Link_Research;
            existingResearch.Disability_Type = updatedResearch.Disability_Type;

            _context.SaveChanges();
            return NoContent();
        }

        return BadRequest();
}


[HttpPut("SetActive")]
    public IActionResult SetActive(int id){
        var research = _context.Research.FirstOrDefault(r => r.Rcode == id);

        if (research == null){
            return NotFound();
        }

             research.Active = true;
            _context.SaveChanges();

            return Ok(new { Message = "Research updated successfully", ResearchId = research.Rcode });
}


}


    



