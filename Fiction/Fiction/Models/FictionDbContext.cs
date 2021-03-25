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
                new Character() { Id = 1, Age = 2, Name = "Atest", StoryId = 1 },
                new Character() { Id = 2, Age = 22, Name = "Btest", StoryId = 2 },
                new Character() { Id = 3, Age = 12, Name = "Ctest", StoryId = 3 });

            modelBuilder.Entity<Story>().HasData(
                new Story() { Id = 1, Name = "Atest" },
                new Story() { Id = 2, Name = "Btest" },
                new Story() { Id = 3, Name = "Ctest" });
        }
    }
}
