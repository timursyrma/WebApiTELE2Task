using DAL.Models;

namespace DAL.Repositories;

public interface IRepository
{
    Task<CitizenModel> Create(CitizenModel citizen);
    Task<IEnumerable<CitizenModel?>> FindAll(string sex = "", uint ageFrom = 0, uint ageTo = 0);
    Task<CitizenModel?> FindById(string id);
}