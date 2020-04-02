using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Models
{
    public class Director
    {
        [Key]
        [Required]
        public int DId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Nacionality { get; set; }
        public bool deleted { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}