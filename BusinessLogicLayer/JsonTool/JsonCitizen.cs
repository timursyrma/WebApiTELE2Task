using BusinessLogicLayer.DTO;
using Newtonsoft.Json;

namespace BusinessLogicLayer.JsonTool;

public class JsonCitizen
{
    public static IEnumerable<CitizenMainDto> ExtractDto(string url)
    {
        using var webClient = new System.Net.WebClient();
        var extractedDtos = (JsonConvert.DeserializeObject<IEnumerable<CitizenMainDto>>(webClient.DownloadString(url)) 
                             ?? throw new InvalidOperationException()).ToArray();
        foreach (var d in extractedDtos)
        {
            d.Age = JsonConvert
                .DeserializeObject<CitizenAdditionalDto>(webClient.DownloadString(url+ "/" + d.Id))!.Age;
        }

        return extractedDtos;
    }
}