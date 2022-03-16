using System.Text.Json.Serialization;

namespace BusinessLogicLayer.DTO;
public class CitizenAdditionalDto
{
    [JsonConstructor]
    public CitizenAdditionalDto(string name, string sex, uint age)
    {
        Age = age;
    }
    public uint Age { get; set; }
}