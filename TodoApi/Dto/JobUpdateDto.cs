using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto
{
    public class JobUpdateDto
    {
        public JobUpdateDto()
        {
        }

        [Required]
        [MaxLength(70)]
        public string Caption { get; set; }

        [Required]
        [MaxLength(500)]
        public string Detail { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DueDate { get; set; }

        public int Urgency { get; set; }

        public bool IsFinished { get; set; } = false;
    }
}
