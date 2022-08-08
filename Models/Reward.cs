using System.ComponentModel.DataAnnotations;

namespace HabitBuilder_Backend2.Models
{
    public class Reward
    {
        public int RewardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Cost { get; set; }

        public IList<HabitReward>? HabitRewards { get; set; }
    

    }
}
