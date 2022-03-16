using System.Text.Json.Serialization;

namespace BusinessLogicLayer.DTO;

public class CitizenMainDto
{
    [JsonConstructor]
    public CitizenMainDto(string id, string name, string sex)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id), "Id is invalid");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name is invalid");
        }

        if (string.IsNullOrWhiteSpace(sex))
        {
            throw new ArgumentNullException(nameof(name), "Sex is invalid");
        }

        Id = id;
        Name = name;
        Sex = sex;
    }

    public string Id { get; }
    public string Name { get; }
    public uint Age { get; set; }
    public string Sex { get; }
}