using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookClient
{
    public class AchievementNotification
    {
        public required string PlayerName { get; set; }
        public required string AchievementName { get; set; }
        public DateTime UnlockedOn { get; set; }
    }
}
