using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blamato.Shared.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DailyGoal { get; set; }
        public DateTime ? StartingDate{ get; set; }
        public DateTime ? EndingDate { get; set; }
        public bool Visible { get; set; } = true;

        public List<Pomodoro> Pomodoros { get; set; }

    }
}
