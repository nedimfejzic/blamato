using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blamato.Shared.Models
{
    public class Pomodoro
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int TimeSpent { get; set; }
        public bool Visible { get; set; } = true;

    }
}
