using System.Net;
using DAL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers;
[ApiController]
[Route("/citizens")]
public class CitizenController : ControllerBase
{
    private readonly ICitizenService _service;
    public CitizenController(ICitizenService service)
    {
        _service = service;
    }
    
    [Route("/citizens/upload")]
    [HttpPost]
    public IEnumerable<CitizenDTO> Initialize([FromQuery] string url)
    {
        return _service.UploadCitizensFromUrl(url);
    }
    
    [Route("/citizens/find")]
    [HttpGet]
    public IActionResult Find([FromQuery] string id)
    {
        if (string.IsNullOrWhiteSpace(id)) 
            return StatusCode((int) HttpStatusCode.BadRequest);
        
        var citizen = _service.FindById(id);
        if (citizen != null)     
        {
            return Ok(citizen);
        }
        return NotFound();

    }
    
    [Route("/citizens/getAllCitizens")]
    [HttpGet]
    public IEnumerable<CitizenModel> GetAllEmployees([FromQuery] string sex, [FromQuery] uint ageFrom, [FromQuery] uint ageTo)
    {
        return _service.FindCitizens(sex, ageFrom, ageTo);
    }

}