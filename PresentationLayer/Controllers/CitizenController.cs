using System.Net;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Views;


namespace BLL.Controllers;
[ApiController]
[Route("/citizens")]
public class CitizenController : Controller
{
    private readonly ICitizenService _service;
    public CitizenController(ICitizenService service)
    {
        _service = service;
    }
    
    [Route("/upload")]
    [HttpPost]
    public IEnumerable<CitizenMainDto> Initialize([FromQuery] string url)
    {
        return _service.UploadCitizensFromUrl(url);
    }
    
    [Route("/find")]
    [HttpGet]
    public IActionResult Find([FromQuery] string id)
    {
        if (string.IsNullOrWhiteSpace(id)) 
            return StatusCode((int) HttpStatusCode.BadRequest);
        
        var citizen = _service.FindById(id).Result;
        if (citizen != null)     
        {
            return Ok(citizen);
        }
        return NotFound();

    }
    
    [Route("/getAllCitizens")]
    [HttpGet]
    public ViewResult GetAllCitizens([FromQuery]string sex = "all", [FromQuery]uint ageFrom = 0, [FromQuery]uint ageTo = 0, int page = 1)
    {
        int pageSize = 3;   // количество элементов на странице
             
        IEnumerable<CitizenModel> citizenModels =  _service.FindCitizens(sex, ageFrom, ageTo).Result;
        int count = citizenModels.Count();
        var items = citizenModels.Skip((page - 1) * pageSize).Take(pageSize);
 
        PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
        IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
        return View(viewModel);
    }
}