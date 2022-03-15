using DAL.Models;

namespace DAL.Repositories;

public interface IRepository
{
    Task<CitizenModel>  AddCitizen(CitizenModel citizen);
    Task<IEnumerable<CitizenModel?>> GetCitizens(string sex = "", uint ageFrom = 0, uint ageTo = 0);
    Task<CitizenModel?> GetById(string id);
}