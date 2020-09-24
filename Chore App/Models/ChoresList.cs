using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chore_App.Models
{
    public class ChoresList
    {   
        public int Id { get; set; }

        [Required]
        public string Chore { get; set; }

        public bool isComplete { get; set; }
    }
}
