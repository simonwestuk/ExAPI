using System;
using System.ComponentModel.DataAnnotations;

namespace ExAPI.Models
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Type { get; set; }
        
        public string Description { get; set; }

        [Required]
        public double Duration { get; set; }

        [Required]
        public double Distance { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

    }
}
