

namespace WebhookExample.Models
{
    public class AchievementNotification
    {
        public required string PlayerName { get; set; }
        public required string AchievementName { get; set; }
        public DateTime UnlockedOn { get; set; }
    }
}
