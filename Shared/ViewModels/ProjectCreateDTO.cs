using blamato.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blamato.Shared.ViewModels
{
    public class ProjectCreateDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, StringLength(1, MinimumLength = 3)]
        public string Description { get; set; }

        [Range(1, 20, ErrorMessage = "Please enter valid Number from 1-20")]
        public int DailyGoal { get; set; }

        public DateTime? StartingDate { get; set; } = DateTime.Now;
        public DateTime? EndingDate { get; set; } = DateTime.Now;
        public bool Visible { get; set; } = true;

        public List<Pomodoro> Pomodoros { get; set; }
    }
}
