using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class UserRepository : IRepository
{
    private readonly DatabaseContext _context;
    public UserRepository(DatabaseContext context) 
    {
        _context = context;
    }
    
    public CitizenModel Create(CitizenModel citizen)
    {
        _context.Citizens.Add(citizen);
        _context.SaveChanges();
        return citizen;
    }

    public async Task<IEnumerable<CitizenModel?>> FindAll(string sex, uint ageFrom, uint ageTo)
        => await _context.Citizens
            .Where(x => x.Sex == sex || sex == "all")
            .Where(x => x.Age >= ageFrom || ageFrom == 0)
            .Where(x => x.Age <= ageTo || ageTo == 0)
            .ToArrayAsync();

    public async Task<CitizenModel?> FindById(string id)
        => await _context.Citizens.Where(c => c.Id == id).FirstOrDefaultAsync();
}