using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiRestTest.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public bool deleted { get; set; }
        public List<Movie> Movies { get; set; }
    }
}