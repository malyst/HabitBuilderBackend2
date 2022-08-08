using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using HabitBuilder_Backend2.Models;

namespace HabitBuilder_Backend2
{
    public class HabitContext : DbContext
    {
        public HabitContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HabitReward>()
            .HasKey(hr => new { hr.HabitId, hr.RewardId });

        }

        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<HabitReward> HabitsRewards { get; set; }
    }
}

