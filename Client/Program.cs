using System.Threading.Channels;
using DAL.DTO;
using Newtonsoft.Json;

using var webClient = new System.Net.WebClient();
var dtos = JsonConvert.DeserializeObject<List<CitizenDTO>>(File.ReadAllText("/home/timur/Projects/RiderProjects/WebApiTELE2Task/Client/citizens.json"));
foreach (var d in dtos)
{
    d.Age = JsonConvert
        .DeserializeObject<CitizenAdditionalDTO>(webClient.DownloadString("http://testlodtask20172.azurewebsites.net/task"+ "/" + d.Id))!.Age;
}

foreach (var d in dtos)
{
    Console.WriteLine($"{d.Age}, {d.Name}, {d.Id}, {d.Sex}");
}