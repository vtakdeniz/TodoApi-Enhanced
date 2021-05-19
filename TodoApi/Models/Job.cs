using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Caption { get; set; }

        [Required]
        [MaxLength(500)]
        public string Detail { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; }

        public int Urgency { get; set; }

        public bool IsFinished { get; set; } = false;

        public List<User_Has_Job> user_Has_jobs { get; set; }

    }
}
