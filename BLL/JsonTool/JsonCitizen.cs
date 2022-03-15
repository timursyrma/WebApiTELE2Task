using System.Text;
using DAL.DTO;
using DAL.Models;
using Newtonsoft.Json;
using Server.Controllers;

namespace Reports.Server.JsonTool;

public class JsonCitizen
{
    public static IEnumerable<CitizenDTO> CitizensDTOS(string url)
    {
        using var webClient = new System.Net.WebClient();
        var dtos = JsonConvert.DeserializeObject<IEnumerable<CitizenDTO>>(webClient.DownloadString(url));
        foreach (var d in dtos)
        {
            d.Age = JsonConvert
                .DeserializeObject<CitizenAdditionalDTO>(webClient.DownloadString(url+ "/" + d.Id))!.Age;
        }

        return dtos;
    }
}