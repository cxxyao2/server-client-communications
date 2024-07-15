using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebhookExample.Models;

namespace WebhookExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {

        private const string ApiKey = "MyTopSecretApiKey";

        [HttpPost("unlock-achievement")]
        public IActionResult UnlockAchievement(
            AchievementNotification notification,
            [FromHeader(Name = "X-API-KEY")] string apiKey)
        {
            if(apiKey != ApiKey) 
            {
                return Unauthorized("Invalid API key");
            }

            Console.WriteLine($"Player {notification.PlayerName} unlcoked '{notification.AchievementName}' on {notification.UnlockedOn}.");
            
            return Ok();
        }
    }
}
