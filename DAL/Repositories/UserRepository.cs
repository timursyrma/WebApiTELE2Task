using DAL.Models;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository : IRepository
{
    private readonly DatabaseContext _context;
    
    public async Task<CitizenModel> Create(CitizenModel citizen)
    {
        await _context.Citizens.AddAsync(citizen);
        await _context.SaveChangesAsync();
        return citizen;
    }

    public async Task<IEnumerable<CitizenModel?>> InitCitizens(IEnumerable<CitizenModel> citizens)
    {
        var initCitizens = citizens as CitizenModel[] ?? citizens.ToArray();
        await _context.Citizens.AddRangeAsync(initCitizens);
        await _context.SaveChangesAsync();
        return initCitizens;
    }


    public async Task<CitizenModel> AddCitizen(CitizenModel citizen)
    {
        await _context.Citizens.AddAsync(citizen);
        return citizen;
    }

    public async Task<IEnumerable<CitizenModel?>> GetCitizens(string sex = "", uint ageFrom = 0, uint ageTo = 0)
        => await _context.Citizens
            .Where(x => x.Sex == sex)
            .Where(x => x.Age >= ageFrom)
            .Where(x => x.Age <= ageTo)
            .ToArrayAsync();

    public async Task<CitizenModel?> GetById(string id)
        => await _context.Citizens.FindAsync(id);
}