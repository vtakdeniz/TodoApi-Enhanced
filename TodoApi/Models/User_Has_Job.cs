using System;
using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models
{
    public class User_Has_Job
    {

        public int UserId { get; set; }
        public User user { get; set; }

        public int JobId { get; set; }
        public Job job { get; set; }

    }
}
