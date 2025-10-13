﻿using System.ComponentModel.DataAnnotations;

namespace studentController.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set; }
        public string Name { get; set; } 
        public int Age { get; set; }
        public string? Address { get; set; } 
        public string Email { get; set; }   
        public string Image { get; set; }



    }
}
