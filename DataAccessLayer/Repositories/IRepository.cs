using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories;

public interface IRepository
{
    CitizenModel Create(CitizenModel citizen);
    Task<IEnumerable<CitizenModel?>> FindAll(string sex, uint ageFrom, uint ageTo);
    Task<CitizenModel?> FindById(string id);
}