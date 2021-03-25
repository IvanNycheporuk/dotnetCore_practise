using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class FictionDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Story> Stories { get; set; }

        private IConfiguration _configuration;

        public FictionDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulder)
        {
            optionsBulder.UseSqlServer(_configuration.GetConnectionString("FictionDbConnection")).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character() { Id = 1, Age = 21, Name = "Test", StoryId = 1 },
                new Character() { Id = 2, Age = 22, Name = "Frodo", StoryId = 2 },
                new Character() { Id = 3, Age = 42, Name = "Joel", StoryId = 2 },
                new Character() { Id = 4, Age = 32, Name = "Sara", StoryId = 2 },
                new Character() { Id = 5, Age = 22, Name = "PotM", StoryId = 2 },
                new Character() { Id = 6, Age = 62, Name = "Warden", StoryId = 2 },
                new Character() { Id = 7, Age = 22, Name = "Naga", StoryId = 2 },
                new Character() { Id = 8, Age = 12, Name = "Harry", StoryId = 3 });

            modelBuilder.Entity<Story>().HasData(
                new Story() { Id = 1, Name = "Some great story" },
                new Story() { Id = 2, Name = "Awesome story with unexpected ending" },
                new Story() { Id = 3, Name = "Great news about that story" });
        }
    }
}
