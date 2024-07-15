using System.Text;
using System.Text.Json;
using WebhookClient;



await PostAchievementAsync();
static async Task PostAchievementAsync()
{
    var httpClient = new HttpClient();

    var achievement = new AchievementNotification
    {
        PlayerName = "Ellie",
        AchievementName = "It can't be for nothing",
        UnlockedOn = new DateTime(2013, 6, 14, 0, 0, 0)
    };

    var json = JsonSerializer.Serialize(achievement);
    var data = new StringContent(json, Encoding.UTF8, "application/json");

    httpClient.DefaultRequestHeaders.Add("X-API-KEY", "MyTopSecretApiKey");

    var url = "https://localhost:7226/api/Achievements/unlock-achievement";

    var response = await httpClient.PostAsync(url, data);

    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Achievement successfully posted.");
    }
    else
    {
        Console.WriteLine($"Failed to post achievement. Status code: {response.StatusCode}");
    }
}
