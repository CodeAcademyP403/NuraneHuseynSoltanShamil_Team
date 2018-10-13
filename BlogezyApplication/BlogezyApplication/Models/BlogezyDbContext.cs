using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models
{
    public class BlogezyDbContext : DbContext
    {
        public BlogezyDbContext(DbContextOptions<BlogezyDbContext> dbContextOptions):base(dbContextOptions) { }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
    }
}
