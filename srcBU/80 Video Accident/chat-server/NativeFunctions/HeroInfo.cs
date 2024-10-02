using System.ComponentModel;
using Microsoft.SemanticKernel;
using Newtonsoft.Json.Linq;

public class HeroInfo
{
    static string apiKey;
    public HeroInfo(string superHeroApiKey)
    {
        apiKey = superHeroApiKey;
    }

    [KernelFunction, Description("Get the alter ego of a superhero. Get the real name of a super hero.")]
    public static string GetAlterEgo(string input)
    {
        // Call the API
        var httpClient = new HttpClient();
        var response = httpClient.GetAsync($"https://superheroapi.com/api/{apiKey}/search/{input}").Result;

        // Get the response
        var responseContent = response.Content.ReadAsStringAsync().Result;

        // Parse the response
        var json = JObject.Parse(responseContent);

        // Get the hero info
        var heroInfo = $"{json["results"][0]["biography"]["full-name"]}";

        // Return the hero info
        return heroInfo;
    }
}
