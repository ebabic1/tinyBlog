using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using tinyBlog.Models;

namespace tinyBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<Post>()
		    .HasMany(e => e.Tags)
		    .WithMany(e => e.Posts)
		    .UsingEntity<PostTag>();
			base.OnModelCreating(builder);
            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Tag>().ToTable("Tags");
            base.OnModelCreating(builder);
        }
    }
}