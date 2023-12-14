using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ResearchApi{

[ApiController]
[Route("[controller]")]
public class ResearchController : ControllerBase{
    private readonly ResearchContext _context;

    public ResearchController(ResearchContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetResearch(int researchId){
    var result = _context.Research.SingleOrDefault(s => s.Rcode == researchId);
        if(result == null){
            return NotFound();
        }

        else{
            return Ok(result);
        }
    }
 
    [HttpGet]
    public IActionResult GetAllResearch([FromServices] IHttpContextAccessor httpContextAccessor){
    var user = httpContextAccessor.HttpContext.User;
    var tenantIdClaim = user.FindFirst("tid");

        if (tenantIdClaim != null){   
            string tenantId = tenantIdClaim.Value;
            var result = _context.Research.Where(r => r.Participant.Contains(tenantId)).ToList();
 
                if (result == null){
                    return NotFound();
            }
            else{
                    return Ok(result);
            }
            
        }
        return BadRequest();
            
    }

    [HttpPost]
    public IActionResult CreateResearch(Research research){
      _context.Research.Add(research);
      _context.SaveChanges();

        return Ok(new { Message = "Research created successfully", ResearchId = research.Rcode });
        }
    
    [HttpDelete]
    public IActionResult DeleteResearch(int id){
     var research = _context.Research.Find(id);
        if (research == null){
            return NotFound();
        }

        _context.Research.Remove(research);
        _context.SaveChanges();

            return NoContent();
        }
    
    [HttpPut]
    public IActionResult UpdateResearch(int id, Research updatedResearch){
    var existingResearch = _context.Research.FirstOrDefault(r => r.Rcode == id);

        if (existingResearch == null){
            return NotFound();
        }

            existingResearch.Title = updatedResearch.Title;
            existingResearch.Compensation = updatedResearch.Compensation;
            existingResearch.Type_Research = updatedResearch.Type_Research;
            existingResearch.Link_Research = updatedResearch.Link_Research;
            existingResearch.Disabillity_Type = updatedResearch.Disabillity_Type;
            existingResearch.Participant = updatedResearch.Participant;
            existingResearch.Allowed_AgeRange = updatedResearch.Allowed_AgeRange;

        _context.SaveChanges();
        return NoContent();
}

    

}
}
