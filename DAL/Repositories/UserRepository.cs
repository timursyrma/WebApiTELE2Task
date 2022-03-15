using DAL.Models;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository : IRepository
{
    private readonly DatabaseContext _context;
    public UserRepository(DatabaseContext context) 
    {
        _context = context;
    }
    
    public async Task<CitizenModel> Create(CitizenModel citizen)
    {
        await _context.Citizens.AddAsync(citizen);
        await _context.SaveChangesAsync();
        return citizen;
    }

    public async Task<IEnumerable<CitizenModel?>> FindAll(string sex = "", uint ageFrom = 0, uint ageTo = 0)
        => await _context.Citizens
            .Where(x => x.Sex == sex)
            .Where(x => x.Age >= ageFrom)
            .Where(x => x.Age <= ageTo)
            .ToArrayAsync();

    public async Task<CitizenModel?> FindById(string id)
        => await _context.Citizens.Where(c => c.Id == id).FirstOrDefaultAsync();
}