using DojoCourse.Module.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DojoCourse.Module.ViewModels
{
    public class PersonPartViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Handedness Handedness { get; set; }

        [Required]
        public DateTime? BirthDateUtc { get; set; }
    }
}
