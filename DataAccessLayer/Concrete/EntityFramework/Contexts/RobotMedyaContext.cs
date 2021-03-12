using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class RobotMedyaContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>().HasKey(at => new { at.ArticleID, at.TagID });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }

        public DbSet<Article> Articles { get; set; }
        

        public DbSet<ArticleTag> ArticleTags { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryType> CategoryTypes { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}
