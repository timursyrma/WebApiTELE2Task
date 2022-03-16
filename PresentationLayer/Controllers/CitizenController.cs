using System.Net;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;


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

    public int GetAllCitizensPageSize { get; set; } = 0;
    [Route("/upload")]
    [HttpPost]
    public IEnumerable<CitizenMainDto> Initialize([FromQuery] string url)
    {
        return _service.UploadCitizensFromUrl(url);
    }
    
    [Route("/find")]
    [HttpGet]
    public CitizenModel? Find([FromQuery] string id)
    {
        if (string.IsNullOrWhiteSpace(id)) 
            return null;
        
        var citizen = _service.FindById(id);
        return citizen?.Result;
    }
    
    [Route("/getAllCitizens")]
    [HttpGet]
    public IEnumerable<CitizenModel> GetAllCitizens([FromQuery]string sex = "all", [FromQuery]uint ageFrom = 0, [FromQuery]uint ageTo = 0, int page = 1)
    {
        IEnumerable<CitizenModel> citizenModels =  _service.FindCitizens(sex, ageFrom, ageTo).Result;
        if (GetAllCitizensPageSize == 0)
            return citizenModels;
        return citizenModels.Skip((page - 1) * GetAllCitizensPageSize).Take(GetAllCitizensPageSize);
    }
}