using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto
{
    public class AddJobToUserDto
    {
        public AddJobToUserDto()
        {
        }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int JobId { get; set; }

    }
}
