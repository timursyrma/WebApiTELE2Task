using DAL.DTO;
using DAL.Models;

namespace Server.Services;

public interface ICitizenService
{
    IEnumerable<CitizenDTO> UploadCitizensFromUrl(string url);
    IEnumerable<CitizenModel?> FindCitizens(string sex = "", uint ageFrom = 0, uint ageTo = 0);
    CitizenModel? FindById(string id);
}