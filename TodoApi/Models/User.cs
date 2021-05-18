using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models
{
    public class User
    {

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

        [Required]
        [MaxLength(250)]
        public string Passwd { get; set; }

        public List<User_Has_Job> user_Has_jobs { get; set; }

        
    }
}
