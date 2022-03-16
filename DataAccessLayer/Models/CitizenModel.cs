using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;
public class CitizenModel
{
    private CitizenModel()
    {
    }
    public CitizenModel(string id, string name,  string sex, uint age)
    {
        Id = id;
        Name = name;
        Sex = sex;
        Age = age;
    }
    public string Id { get; private init; }
    public string Name { get; private init;}
    public string Sex { get; private init;}
    public uint Age { get; private init;}

    
}