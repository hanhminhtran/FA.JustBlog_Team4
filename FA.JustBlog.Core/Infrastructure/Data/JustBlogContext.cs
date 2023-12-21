using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core
{
    public class JustBlogContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-6UKDON56;database=JustBlogDb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTagMap>().HasKey(sc => new { sc.PostId, sc.TagId });
        }
    }
}
