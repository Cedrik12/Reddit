using Microsoft.EntityFrameworkCore;
using Reddit.Models.Entities;

namespace RedditButBetter.Models.DAL
{
    public class RedditContext : DbContext
    {
        public RedditContext() { }

        public RedditContext(DbContextOptions<RedditContext> options) : base(options) { }

        public DbSet<Commentaire>? commentaires { get; set; }
        public DbSet<Lien>? liens { get; set; }
        public DbSet<Utilisateur>? utilisateurs { get; set; }
        public DbSet<Vote>? votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilisateur>().HasData(

                new Utilisateur()
                {
                    id=5,
                    username="cedrik",
                    password="yo",
                    email="cedrikcool"
                });
        }
    }
}
