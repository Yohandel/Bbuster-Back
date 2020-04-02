using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiRestTest.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Amount { get; set; }
        public bool deleted { get; set; }
        [Required]
        public int directorId { get; set; }
        public Director director { get; set; }
        [Required]
        public int categoryId { get; set; }
        public Category Category { get; set; }

    }
}