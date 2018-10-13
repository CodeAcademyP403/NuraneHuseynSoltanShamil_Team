using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Article Article { get; set; }
        public int ArticleId { get; set; }

        public AppUser AppUser { get; set; }
        public string UserId { get; set; }
    }
}
