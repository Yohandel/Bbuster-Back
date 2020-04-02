using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiRestTest
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int id_user { get; set; }
        [Required]
        public int id_movie { get; set; }
        [Required]
        public DateTime Created_At { get; set; }
        public bool deleted { get; set; }
    }
}