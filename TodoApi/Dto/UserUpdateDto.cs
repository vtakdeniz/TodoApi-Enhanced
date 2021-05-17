﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto
{
    public class UserUpdateDto
    {
        public UserUpdateDto()
        {
        }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Mail { get; set; }

        [Required]
        [MaxLength(250)]
        public string Passwd { get; set; }

    }
}
