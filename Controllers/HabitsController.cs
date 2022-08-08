using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HabitBuilder_Backend2;
using HabitBuilder_Backend2.Models;

namespace HabitBuilder_Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly HabitContext _context;

        public HabitsController(HabitContext context)
        {
            _context = context;
        }

        // GET: api/Habits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habit>>> GetHabits()
        {
          if (_context.Habits == null)
          {
              return NotFound();
          }
            return await _context.Habits.Include(m => m.HabitRewards).ThenInclude(s => s.Rewards).AsNoTracking().ToListAsync();
        }

        // GET: api/Habits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Habit>> GetHabit(int id)
        {
          if (_context.Habits == null)
          {
              return NotFound();
          }
            var habit = await _context.Habits.Include(m => m.HabitRewards).ThenInclude(s => s.Rewards).AsNoTracking().FirstOrDefaultAsync(m => m.HabitId == id);

            if (habit == null)
            {
                return NotFound();
            }

            return habit;
        }

        // PUT: api/HabitReward/5/6
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{habitId}/{rewardId}")]
        public async Task<IActionResult> PutHabitReward(int habitId, int rewardId)
        {

            Habit habit = await _context.Habits.FindAsync(habitId);


            HabitReward hr = new HabitReward();
            hr.HabitId = habitId;
            hr.RewardId = rewardId;
            if (habit.HabitRewards == null)
            {
                habit.HabitRewards = new List<HabitReward>();
            }
            habit.HabitRewards.Add(hr);

            _context.Entry(habit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitExists(habitId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Habits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habit>> PostHabit(Habit habit)
        {
          if (_context.Habits == null)
          {
              return Problem("Entity set 'HabitContext.Habits'  is null.");
          }
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabit", new { id = habit.HabitId }, habit);
        }

        // DELETE: api/Habits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            if (_context.Habits == null)
            {
                return NotFound();
            }
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }

            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitExists(int id)
        {
            return (_context.Habits?.Any(e => e.HabitId == id)).GetValueOrDefault();
        }
    }
}
