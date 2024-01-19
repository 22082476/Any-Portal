using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ResearchController : ControllerBase{
    private readonly ResearchContext _context;

    public ResearchController(ResearchContext context){
        _context = context;
    }


    [HttpGet]
    [Route("ByResearchId/{researchId}")]
    public IActionResult GetResearch(int researchId){
    var result = _context.Research.SingleOrDefault(s => s.Rcode == researchId);
       
        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }

    [HttpGet]
    [Route("ByPostalCode/{researchId}")]
    public IActionResult GetPostalCodes(int researchId){
    var result = _context.PostalCodeRanges.Where(s => s.ResearchId == researchId);
       
        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }
    
    [HttpGet]
    [Route("ByAgeRange/{researchId}")]
    public IActionResult GetAllowedAgeRanges(int researchId){
    var result = _context.allowed_AgeRanges.SingleOrDefault(s => s.ResearchId == researchId);
       
        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }
 
 
    [HttpGet]
    [Route("ByCompanyId/{companyId}")]
    public IActionResult GetAllResearch(string companyId){
    var result = _context.Research.Where(s => s.CompanyId == companyId).ToList();

        if(result.Count == 0){
            return NotFound();
        }
            return Ok(result);
    }
    [HttpGet]
    public IActionResult GetAllResearch(){
    var result = _context.Research.ToList();

        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }

    [HttpGet]
    [Route("ByParticipatedId/{Id}")]
    public IActionResult GetAllParticipated(int Id){
    var result = _context.Participants.Where(s => s.Id == Id).ToList();

        if(result == null){
            return NotFound();
        }
            return Ok(result);
    }


    [HttpPost]
    [Route("Research")]
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


    [HttpPost]
    [Route("Participant")]
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


    [HttpPost]
    [Route("CreateAllowed_AgeRange")]
    public IActionResult CreateAllowed_AgeRange(Allowed_AgeRange allowed_AgeRange){

        if(allowed_AgeRange == null){
        return BadRequest();
        }

        try{
            _context.allowed_AgeRanges.Add(allowed_AgeRange);
            _context.SaveChanges();
            return Ok(new { Message = "AgeRange created successfully", ResearchId = allowed_AgeRange.Allowed_AgeRangeId});
        }

      
        catch (Exception ex){
            return BadRequest(new { Message = "Failed to create AgeRange", Error = ex.Message });
        }
    }
    

    [HttpPost]
    [Route("PostalCode_Range")]
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
    [Route("DeleteResearch")]
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

     [HttpDelete]
     [Route("DeletePostalcode")]

    public IActionResult DeletePostalcode(int id){
        var postalCode = _context.PostalCodeRanges.SingleOrDefault(R => R.Id == id);
        if (postalCode == null){
            return NotFound();
        }

        _context.PostalCodeRanges.Remove(postalCode);
        
        try{
        _context.SaveChanges();

            return Ok();
        }
        
        catch(DbUpdateException e){
            System.Console.WriteLine(e);
            return BadRequest();
        }
    }
   
[HttpPut]
[Route("Research/{id}")]
public IActionResult UpdateResearch(int id, [FromBody] Research updatedResearch)
{
    var existingResearch = _context.Research.FirstOrDefault(r => r.Rcode == id);

    if (existingResearch == null)
    {
        return NotFound();
    }

    if (!existingResearch.Active)
    {
        existingResearch.Title = updatedResearch.Title;
        existingResearch.Compensation = updatedResearch.Compensation;
        existingResearch.Type_Research = updatedResearch.Type_Research;
        existingResearch.Link_Research = updatedResearch.Link_Research;
        existingResearch.Disability_Type = updatedResearch.Disability_Type;
        existingResearch.Active = updatedResearch.Active;
        existingResearch.Description = updatedResearch.Description;
        _context.SaveChanges();
        return Ok();
    }

    return BadRequest();
}

[HttpPut]
[Route("UpdateAllowed_AgeRange/{id}")]
public IActionResult UpdateAllowed_AgeRange(int id, Allowed_AgeRange updatedAllowed_AgeRange)
{
    var existingAgeRange = _context.allowed_AgeRanges.FirstOrDefault(a => a.Id == id);

    if (existingAgeRange == null)
    {
        return NotFound();
    }

    try
    {
        existingAgeRange.Allowed_AgeRangeId = updatedAllowed_AgeRange.Allowed_AgeRangeId;
        _context.SaveChanges();
        return Ok(new {Message = "AgeRange updated"});
    }
    catch (Exception ex)
    {
        return BadRequest(new { Message = "Failed to update AgeRange", Error = ex.Message });
    }
}

[HttpPut]
[Route("UpdatePostalCodeRange/{id}")]
public IActionResult UpdatePostalCodeRange(int id, PostalCodeRange updatedPostalCodeRange)
{
    var existingPostalCodeRange = _context.PostalCodeRanges.SingleOrDefault(p => p.Id == id);

    if (existingPostalCodeRange == null)
    {
        return Ok(new {Message = "PostalcodeRange updated"});
    }

    try
    {
        existingPostalCodeRange.From_Postalcode = updatedPostalCodeRange.From_Postalcode;
        existingPostalCodeRange.Till_Postalcode = updatedPostalCodeRange.Till_Postalcode;

        _context.SaveChanges();
        return NoContent();
    }
    catch (Exception ex)
    {
        return BadRequest(new { Message = "Failed to update PostalCodeRange", Error = ex.Message });
    }
}
}


    


