using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TodoApi.Dto;

namespace TodoApi.ViewModels
{
    //View models are created to prevent self referencing loop exceptions
    public class JobHasUserVm
    {
        public JobHasUserVm()
        {
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Caption { get; set; }

        [Required]
        [MaxLength(500)]
        public string Detail { get; set; }


        public int Urgency { get; set; }


        public bool IsFinished { get; set; } = false;

        public List<UserReadDto> owners { get; set; }
    }
}
