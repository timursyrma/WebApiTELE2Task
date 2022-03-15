using DAL.DTO;

namespace DAL.Models;

public class CitizenModel
{
    private CitizenModel()
    {
    }
    public CitizenModel(CitizenDTO citizenDto)
    {
        Name = citizenDto.Name;
        Id = citizenDto.Id;
        Age = citizenDto.Age;
        Sex = citizenDto.Sex;
    }
    public string Id { get; private init; }
    public string Name { get; private init; }
    public uint Age { get; private init; }
    public string Sex { get; private init; }

    
}