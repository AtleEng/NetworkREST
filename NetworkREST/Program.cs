using RestSharp;
using System.Text.Json;

RestClient client = new RestClient("https://swapi.py4e.com/api/");

RestRequest request = new RestRequest("people/");

RestResponse response = client.GetAsync(request).Result;

ResultObject resultObj = JsonSerializer.Deserialize<ResultObject>(response.Content);

if (resultObj != null)
{
    for (int i = 0; i < resultObj.results.Count; i++)
    {
        Console.WriteLine($"{i + 1} = {resultObj.results[i].name}");
    }

    Console.ReadLine();
}


public class Person
{
    public string name { get; set; }

}

public class ResultObject
{
    public List<Person> results { get; set; }
}