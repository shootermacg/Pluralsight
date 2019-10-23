using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WiredBrainCoffee.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(25)]
        [Required]
        public string Message { get; set; }

    }
}
