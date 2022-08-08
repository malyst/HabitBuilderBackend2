using System.ComponentModel.DataAnnotations.Schema;

namespace HabitBuilder_Backend2.Models
{
    [Table("HabitRewards")]
    public class HabitReward
    {
        public Habit? Habits { get; set; }
        public int HabitId { get; set; }
        public Reward? Rewards { get; set; }
        public int RewardId { get; set; }
    }
}
