using BusinessLogicLayer.DTO;
using BusinessLogicLayer.JsonTool;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services;

public class CitizenService : ICitizenService
{
    private readonly IRepository _repository;
    public CitizenService(IRepository repository)
    {
         _repository = repository;
    }
    public IEnumerable<CitizenMainDto> UploadCitizensFromUrl(string url)
    {
        var extractedDtos = JsonCitizen.ExtractDto(url).ToArray();
        foreach (var d in extractedDtos)
            _repository.Create(new CitizenModel(d.Id, d.Name, d.Sex, d.Age));
        return extractedDtos;
    }

    public Task<IEnumerable<CitizenModel?>> FindCitizens(string sex, uint ageFrom = 0, uint ageTo = 0)
        => _repository.FindAll(sex, ageFrom, ageTo);

    public Task<CitizenModel?> FindById(string id)
        => _repository.FindById(id);
}