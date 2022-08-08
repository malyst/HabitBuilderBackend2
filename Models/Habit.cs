using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitBuilder_Backend2.Models
{
    public class Habit
    {
        public int HabitId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int DailyCompletion { get; set; }
        [Required]
        public int MonthlyCompletion { get; set; }
        [Required]
        public int YearlyCompletion { get; set; }
        [Required]
        public int DateCreated { get; set; }
        public IList<HabitReward>? HabitRewards { get; set; }

    }
}
