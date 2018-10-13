using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models
{
    public class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PublicDate { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public bool Visibility { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

    
}
