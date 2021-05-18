using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Dto
{
    public class JobReadDto
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Caption { get; set; }

        [Required]
        [MaxLength(500)]
        public string Detail { get; set; }


        public int Urgency { get; set; }


        public bool IsFinished { get; set; } = false;

        public List<User> owners { get; set; }
    }
}
