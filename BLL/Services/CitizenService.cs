using System.Net;
using System.Text;
using DAL.DTO;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Reports.Server.JsonTool;

namespace Server.Services;

public class CitizenService : ICitizenService
{
    private readonly IRepository _repository;
    public CitizenService(IRepository repository)
    {
         _repository = repository;
    }
    public IEnumerable<CitizenDTO> UploadCitizensFromUrl(string url)
    {
        var dtos = JsonCitizen.CitizensDTOS(url);
        foreach (var d in dtos)
            _repository.Create(new CitizenModel(d));
        return dtos;
    }

    public IEnumerable<CitizenModel?> FindCitizens(string sex, uint ageFrom = 0, uint ageTo = 0)
        => _repository.FindAll(sex, ageFrom, ageTo).Result;

    public CitizenModel? FindById(string id)
        => _repository.FindById(id).Result;
}