using BusinessLogicLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services;

public interface ICitizenService
{
    IEnumerable<CitizenMainDto> UploadCitizensFromUrl(string url);
    Task<IEnumerable<CitizenModel?>> FindCitizens(string sex = "", uint ageFrom = 0, uint ageTo = 0);
    Task<CitizenModel?> FindById(string id);
}