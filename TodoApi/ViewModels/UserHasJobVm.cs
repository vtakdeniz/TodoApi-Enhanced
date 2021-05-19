using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TodoApi.Dto;

namespace TodoApi.ViewModels
{
    public class UserHasJobVm
    {
        public UserHasJobVm()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Mail { get; set; }

        public List<JobReadDto> jobs { get; set; }
    }
}
