using System.Text.Json.Serialization;

namespace DAL.DTO;

public class CitizenAdditionalDTO
{
    [JsonConstructor]
    public CitizenAdditionalDTO(string name, string sex, uint age)
    {
        Age = age;
    }
    public uint Age { get; set; }
}