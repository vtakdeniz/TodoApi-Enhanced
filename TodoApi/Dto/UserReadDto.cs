using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Dto
{
    public class UserReadDto
    {
        public UserReadDto() {

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
